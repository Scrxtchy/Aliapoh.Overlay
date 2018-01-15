using System;
using System.Threading.Tasks;

using CefSharp;
using CefSharp.Internals;
using CefSharp.ModelBinding;
using CefSharp.OffScreen;
using System.Drawing;
using System.Drawing.Imaging;

namespace Aliapoh.Overlay
{
    public class OverlayRenderer : IRenderWebBrowser
    {
        private ManagedCefBrowserAdapter managedCefBrowserAdapter;
        public Bitmap Bitmap { get; protected set; }
        public readonly object BitmapLock = new object();
        private Size size = new Size(1366, 768);
        private IBrowser browser;
        private bool browserCreated;
        public bool IsBrowserInitialized { get; private set; }
        public bool IsLoading { get; private set; }
        public string TooltipText { get; private set; }
        public string Address { get; private set; }
        public bool CanGoBack { get; private set; }
        public bool PopupOpen { get; protected set; }
        public bool CanGoForward { get; private set; }
        public BrowserSettings BrowserSettings { get; private set; }
        public IRequestContext RequestContext { get; private set; }
        public IJsDialogHandler JsDialogHandler { get; set; }
        public IDialogHandler DialogHandler { get; set; }
        public IDownloadHandler DownloadHandler { get; set; }
        public IKeyboardHandler KeyboardHandler { get; set; }
        public ILoadHandler LoadHandler { get; set; }
        public ILifeSpanHandler LifeSpanHandler { get; set; }
        public IDisplayHandler DisplayHandler { get; set; }
        public IContextMenuHandler MenuHandler { get; set; }
        public IFocusHandler FocusHandler { get; set; }
        public IRequestHandler RequestHandler { get; set; }
        public IDragHandler DragHandler { get; set; }
        public IResourceHandlerFactory ResourceHandlerFactory { get; set; }
        public IGeolocationHandler GeolocationHandler { get; set; }
        public IBitmapFactory BitmapFactory { get; set; }
        public IRenderProcessMessageHandler RenderProcessMessageHandler { get; set; }
        public IFindHandler FindHandler { get; set; }
        public event EventHandler<LoadErrorEventArgs> LoadError;
        public event EventHandler<FrameLoadStartEventArgs> FrameLoadStart;
        public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;
        public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;
        public event EventHandler BrowserInitialized;
        public event EventHandler<StatusMessageEventArgs> StatusMessage;
        public event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;
        public event EventHandler<AddressChangedEventArgs> AddressChanged;
        public event EventHandler<TitleChangedEventArgs> TitleChanged;
        public event EventHandler NewScreenshot;
        public bool CanExecuteJavascriptInMainFrame { get; private set; }
        private Point popupPosition;
        private Size popupSize;
        public Bitmap Popup { get; protected set; }

        public OverlayRenderer(string address = "", BrowserSettings browserSettings = null,
            RequestContext requestContext = null, bool automaticallyCreateBrowser = true)
        {
            if (!Cef.IsInitialized && !Cef.Initialize())
            {
                throw new InvalidOperationException("Cef::Initialize() failed");
            }

            BitmapFactory = new BitmapFactory(BitmapLock);

            ResourceHandlerFactory = new DefaultResourceHandlerFactory();
            BrowserSettings = browserSettings ?? new BrowserSettings();
            RequestContext = requestContext;

            Cef.AddDisposable(this);
            Address = address;

            managedCefBrowserAdapter = new ManagedCefBrowserAdapter(this, true);

            if (automaticallyCreateBrowser)
            {
                CreateBrowser(IntPtr.Zero);
            }

            popupPosition = new Point();
            popupSize = new Size();
        }

        ~OverlayRenderer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Don't reference event listeners any longer:
            LoadError = null;
            FrameLoadStart = null;
            FrameLoadEnd = null;
            ConsoleMessage = null;
            BrowserInitialized = null;
            StatusMessage = null;
            LoadingStateChanged = null;
            AddressChanged = null;

            Cef.RemoveDisposable(this);

            if (disposing)
            {
                browser = null;
                IsBrowserInitialized = false;

                if (Bitmap != null)
                {
                    Bitmap.Dispose();
                    Bitmap = null;
                }

                if (BrowserSettings != null)
                {
                    BrowserSettings.Dispose();
                    BrowserSettings = null;
                }

                if (managedCefBrowserAdapter != null)
                {
                    if (!managedCefBrowserAdapter.IsDisposed)
                    {
                        managedCefBrowserAdapter.Dispose();
                    }
                    managedCefBrowserAdapter = null;
                }
            }
        }
        
        public Size PopupSize
        {
            get { return popupSize; }
        }
        
        public Point PopupPosition
        {
            get { return popupPosition; }
        }
        
        public void CreateBrowser(IntPtr windowHandle)
        {
            if (browserCreated)
            {
                throw new Exception("An instance of the underlying offscreen browser has already been created, this method can only be called once.");
            }

            browserCreated = true;

            managedCefBrowserAdapter.CreateOffscreenBrowser(windowHandle, BrowserSettings, (RequestContext)RequestContext, Address);
        }
        
        public Size Size
        {
            get { return size; }
            set
            {
                if (size != value)
                {
                    size = value;

                    if (IsBrowserInitialized)
                    {
                        browser.GetHost().WasResized();
                    }
                }
            }
        }
        
        public Bitmap ScreenshotOrNull(PopupBlending blend = PopupBlending.Main)
        {
            lock (BitmapLock)
            {
                if (blend == PopupBlending.Blend)
                {
                    if (PopupOpen && Bitmap != null && Popup != null)
                    {
                        return MergeBitmaps(Bitmap, Popup);
                    }

                    return Bitmap == null ? null : new Bitmap(Bitmap);
                }
                else if (blend == PopupBlending.Popup)
                {
                    if (PopupOpen)
                    {
                        return Popup == null ? null : new Bitmap(Popup);
                    }

                    return null;
                }

                return Bitmap == null ? null : new Bitmap(Bitmap);
            }
        }
        
        protected void SetBitmap(Bitmap bitmap)
        {
            Bitmap = (Bitmap)bitmap.Clone();
        }
        
        public Task<Bitmap> ScreenshotAsync(bool ignoreExistingScreenshot = false, PopupBlending blend = PopupBlending.Main)
        {
            // Try our luck and see if there is already a screenshot, to save us creating a new thread for nothing.
            var screenshot = ScreenshotOrNull(blend);

            var completionSource = new TaskCompletionSource<Bitmap>();

            if (screenshot == null || ignoreExistingScreenshot)
            {
                EventHandler newScreenshot = null; // otherwise we cannot reference ourselves in the anonymous method below

                newScreenshot = (sender, e) =>
                {
                    // Chromium has rendered.  Tell the task about it.
                    NewScreenshot -= newScreenshot;

                    completionSource.TrySetResultAsync(ScreenshotOrNull());
                };

                NewScreenshot += newScreenshot;
            }
            else
            {
                completionSource.TrySetResultAsync(screenshot);
            }

            return completionSource.Task;
        }
        
        public void Load(string url)
        {
            Address = url;

            //Destroy the frame wrapper when we're done
            using (var frame = this.GetMainFrame())
            {
                frame.LoadUrl(url);
            }
        }
        
        public void RegisterJsObject(string name, object objectToBind, BindingOptions options = null)
        {
            if (IsBrowserInitialized)
            {
                throw new Exception("Browser is already initialized. RegisterJsObject must be" +
                                    "called before the underlying CEF browser is created.");
            }

            //Enable WCF if not already enabled
            CefSharpSettings.WcfEnabled = true;

            managedCefBrowserAdapter.RegisterJsObject(name, objectToBind, options);
        }
        
        public void RegisterAsyncJsObject(string name, object objectToBind, BindingOptions options = null)
        {
            if (IsBrowserInitialized)
            {
                throw new Exception("Browser is already initialized. RegisterJsObject must be" +
                                    "called before the underlying CEF browser is created.");
            }
            managedCefBrowserAdapter.RegisterAsyncJsObject(name, objectToBind, options);
        }
        
        bool IWebBrowser.Focus()
        {
            // no control to focus for offscreen browser
            return false;
        }
        
        public IBrowser GetBrowser()
        {
            this.ThrowExceptionIfBrowserNotInitialized();

            return browser;
        }
        
        ScreenInfo IRenderWebBrowser.GetScreenInfo()
        {
            var screenInfo = new ScreenInfo(scaleFactor: 1.0F);

            return screenInfo;
        }
        
        ViewRect IRenderWebBrowser.GetViewRect()
        {
            var viewRect = new ViewRect(size.Width, size.Height);

            return viewRect;
        }

        bool IRenderWebBrowser.GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY)
        {
            screenX = 0;
            screenY = 0;

            return false;
        }

        public BitmapInfo CreateBitmapInfo(bool isPopup)
        {
            return BitmapFactory.CreateBitmap(isPopup, 1.0F);
        }
        
        BitmapInfo IRenderWebBrowser.CreateBitmapInfo(bool isPopup)
        {
            if (BitmapFactory == null)
            {
                throw new Exception("BitmapFactory cannot be null");
            }
            return BitmapFactory.CreateBitmap(isPopup, 1.0F);
        }
        
        void IRenderWebBrowser.OnPaint(BitmapInfo bitmapInfo)
        {
            InvokeRenderAsync(bitmapInfo);

            var handler = NewScreenshot;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        
        protected virtual void InvokeRenderAsync(BitmapInfo bitmapInfo)
        {
            var gdiBitmapInfo = (GdiBitmapInfo)bitmapInfo;

            if (bitmapInfo.CreateNewBitmap)
            {
                if (gdiBitmapInfo.IsPopup)
                {
                    if (Popup != null)
                    {
                        Popup.Dispose();
                        Popup = null;
                    }

                    Popup = gdiBitmapInfo.CreateBitmap();
                }
                else
                {
                    if (Bitmap != null)
                    {
                        Bitmap.Dispose();
                        Bitmap = null;
                    }

                    Bitmap = gdiBitmapInfo.CreateBitmap();
                }
            }
        }
        
        void IRenderWebBrowser.SetCursor(IntPtr handle, CursorType type)
        {
        }
        
        bool IRenderWebBrowser.StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y)
        {
            return false;
        }

        void IRenderWebBrowser.UpdateDragCursor(DragOperationsMask operation)
        {
            //TODO: Someone should implement this
        }
        
        void IRenderWebBrowser.SetPopupIsOpen(bool show)
        {
            PopupOpen = show;

            //Cleanup the old popup now that's it's not open
            if (!PopupOpen && Popup != null)
            {
                Popup.Dispose();
                Popup = null;
            }
        }

        void IRenderWebBrowser.SetPopupSizeAndPosition(int width, int height, int x, int y)
        {
            popupPosition.X = x;
            popupPosition.Y = y;
            popupSize.Width = width;
            popupSize.Height = height;
        }

        void IRenderWebBrowser.OnImeCompositionRangeChanged(Range selectedRange, Rect[] characterBounds)
        {
            //TODO: Implement this
        }
        
        void IWebBrowserInternal.OnConsoleMessage(ConsoleMessageEventArgs args)
        {
            var handler = ConsoleMessage;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        
        void IWebBrowserInternal.OnFrameLoadStart(FrameLoadStartEventArgs args)
        {
            var handler = FrameLoadStart;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        
        void IWebBrowserInternal.OnFrameLoadEnd(FrameLoadEndEventArgs args)
        {
            var handler = FrameLoadEnd;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        
        void IWebBrowserInternal.OnAfterBrowserCreated(IBrowser browser)
        {
            this.browser = browser;

            IsBrowserInitialized = true;

            var handler = BrowserInitialized;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        
        void IWebBrowserInternal.OnLoadError(LoadErrorEventArgs args)
        {
            var handler = LoadError;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        
        IBrowserAdapter IWebBrowserInternal.BrowserAdapter
        {
            get { return managedCefBrowserAdapter; }
        }
        
        bool IWebBrowserInternal.HasParent { get; set; }
        
        void IWebBrowserInternal.OnStatusMessage(StatusMessageEventArgs args)
        {
            var handler = StatusMessage;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Sets the address.
        /// </summary>
        /// <param name="args">The <see cref="AddressChangedEventArgs"/> instance containing the event data.</param>
        void IWebBrowserInternal.SetAddress(AddressChangedEventArgs args)
        {
            Address = args.Address;

            var handler = AddressChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Sets the loading state change.
        /// </summary>
        /// <param name="args">The <see cref="LoadingStateChangedEventArgs"/> instance containing the event data.</param>
        void IWebBrowserInternal.SetLoadingStateChange(LoadingStateChangedEventArgs args)
        {
            CanGoBack = args.CanGoBack;
            CanGoForward = args.CanGoForward;
            IsLoading = args.IsLoading;

            var handler = LoadingStateChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <param name="args">The <see cref="TitleChangedEventArgs"/> instance containing the event data.</param>
        void IWebBrowserInternal.SetTitle(TitleChangedEventArgs args)
        {
            var handler = TitleChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Sets the tooltip text.
        /// </summary>
        /// <param name="tooltipText">The tooltip text.</param>
        void IWebBrowserInternal.SetTooltipText(string tooltipText)
        {
            TooltipText = tooltipText;
        }

        void IWebBrowserInternal.SetCanExecuteJavascriptOnMainFrame(bool canExecute)
        {
            CanExecuteJavascriptInMainFrame = canExecute;
        }

        /// <summary>
        /// Creates a new bitmap with the dimensions of firstBitmap, then
        /// draws the firstBitmap, then overlays the secondBitmap
        /// </summary>
        /// <param name="firstBitmap">First bitmap, this will be the first image drawn</param>
        /// <param name="secondBitmap">Second bitmap, this image will be drawn on the first</param>
        /// <returns>The merged bitmap, size of firstBitmap</returns>
        private Bitmap MergeBitmaps(Bitmap firstBitmap, Bitmap secondBitmap)
        {
            var mergedBitmap = new Bitmap(firstBitmap.Width, firstBitmap.Height, PixelFormat.Format32bppPArgb);
            using (var g = Graphics.FromImage(mergedBitmap))
            {
                g.DrawImage(firstBitmap, new Rectangle(0, 0, firstBitmap.Width, firstBitmap.Height));
                g.DrawImage(secondBitmap, new Rectangle((int)popupPosition.X, (int)popupPosition.Y, secondBitmap.Width, secondBitmap.Height));
            }
            return mergedBitmap;
        }
    }
}
