using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace Aliapoh.Overlay.CefManager
{
    public class Downloader
    {
        public static string UserAgent = "AliapohDownloader";

        public int FileCount { get; private set; }
        public long QueuedSize { get; private set; }
        public long TotalDownloadSize { get; private set; }
        public long PrevDownloadSize { get; private set; }
        public long CurrentDownloadSize { get; private set; }
        public long CurrentFileSize { get; private set; }
        public double DownloadSpeed { get; private set; }
        public string CurrentFile { get; private set; }

        public bool DownloadStarted = false;
        public Dictionary<string, string> Queue = new Dictionary<string, string>();
        public DateTime LastDate = DateTime.Now;

        public void Initializer()
        {
            QueuedSize = 0;
            TotalDownloadSize = 0;
            PrevDownloadSize = 0;
            CurrentDownloadSize = 0;
            CurrentFileSize = 0;
            DownloadSpeed = 0;
            FileCount = 0;
            CurrentFile = "";
            DownloadStarted = false;
            Queue = new Dictionary<string, string>();
            LastDate = DateTime.Now;
        }

        public void QueueDownload(string URL, string Path)
        {
            if (!DownloadStarted)
            {
                QueuedSize += GetWebFileSize(URL);
                Queue.Add(URL, Path);
            }
        }

        public void StartDownload()
        {
            if (!DownloadStarted)
            {
                DownloadStarted = true;
                OnStartDownloading(EventArgs.Empty);
                new Thread((ThreadStart)delegate
                {
                    TotalDownloadSize = 0;
                    CurrentDownloadSize = 0;
                    FileCount = 0;
                    DownloadSpeed = 0;

                    new Thread((ThreadStart)delegate { ApprovalTimeCalculator(); }).Start();

                    foreach (var i in Queue)
                    {
                        OnStartSingleFileDownload(EventArgs.Empty);
                        var httpReq = GetWebURLResponse(i.Key);
                        CurrentFile = i.Value.Substring(i.Value.LastIndexOf("\\") + 1);
                        CurrentFileSize = httpReq.ContentLength;
                        DownloadFile(httpReq, i.Value);
                    }

                    DownloadEnded();
                }).Start();
            }
        }

        private void DownloadFile(HttpWebResponse URL, string Path)
        {
            DownloadFile(URL, Path, 524288);
        }

        private void DownloadFile(HttpWebResponse URL, string Path, int BufferSize = 524288)
        {
            LB_START:
            long fileSize = 0;
            int bufferSize = BufferSize;
            long existLen = 0;

            FileStream saveFileStream;
            if (File.Exists(Path))
            {
                FileInfo destinationFileInfo = new FileInfo(Path);
                existLen = destinationFileInfo.Length;
            }

            if (existLen == URL.ContentLength)
            {
                TotalDownloadSize += CurrentFileSize;
                CurrentDownloadSize = 0;
                OnSingleFileComplete(EventArgs.Empty);
                URL.Close();
                return;
            }
            else if (existLen != URL.ContentLength)
            {
                File.Delete(Path);
            }

            if (existLen > 0) saveFileStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            else saveFileStream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            try
            {
                using (Stream resStream = URL.GetResponseStream())
                {
                    fileSize = URL.ContentLength;

                    int byteSize;
                    byte[] downBuffer = new byte[bufferSize];
                    while ((byteSize = resStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                    {
                        CurrentDownloadSize = saveFileStream.Length;
                        saveFileStream.Write(downBuffer, 0, byteSize);
                        OnFileDownloadSizeChanged(EventArgs.Empty);
                    }
                }

                TotalDownloadSize += CurrentFileSize;
                CurrentDownloadSize = 0;
                OnSingleFileComplete(EventArgs.Empty);
                URL.Close();
                saveFileStream.Close();
            }
            catch
            {
                saveFileStream.Close();
                goto LB_START;
            }
        }

        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|           UTILS          |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        private void DownloadEnded()
        {
            OnFileDownloadEnded(EventArgs.Empty);
            DownloadStarted = false;
        }

        public void ApprovalTimeCalculator()
        {
            while (DownloadStarted)
            {
                var tick = (DateTime.Now.Ticks - LastDate.Ticks) / 10000000d;
                LastDate = DateTime.Now;
                DownloadSpeed = (CurrentDownloadSize - PrevDownloadSize) / tick;
                PrevDownloadSize = CurrentDownloadSize;
                ApprovalTime();
                OnCalculateBPS(EventArgs.Empty);
                Thread.Sleep(1000);
            }
        }

        public long GetWebFileSize(string URL)
        {
            long size = 0;
            HttpWebRequest httpReq;
            HttpWebResponse httpRes;
            httpReq = (HttpWebRequest)WebRequest.Create(URL);
            httpReq.MediaType = "application/octet-stream";
            httpReq.MediaType = "application/octet-stream";
            httpReq.Timeout = 10000;
            httpReq.UserAgent = UserAgent;
            httpRes = (HttpWebResponse)httpReq.GetResponse();
            size = httpRes.ContentLength;
            httpRes.Close();
            return size;
        }

        public HttpWebResponse GetWebURLResponse(string URL)
        {
            LN_F:
            try
            {
                HttpWebRequest httpReq;
                HttpWebResponse httpRes;
                httpReq = (HttpWebRequest)WebRequest.Create(URL);
                httpReq.MediaType = "application/octet-stream";
                httpReq.Timeout = 10000;
                httpReq.UserAgent = UserAgent;
                httpRes = (HttpWebResponse)httpReq.GetResponse();
                return httpRes;
            }
            catch
            {
                goto LN_F;
            }
        }

        public int ApprovalTimeInt()
        {
            var RequireSize = QueuedSize - (TotalDownloadSize + CurrentDownloadSize);
            int RequireSeconds = (int)Math.Ceiling(RequireSize / DownloadSpeed);

            return RequireSeconds;
        }

        public string ApprovalTime()
        {
            var RequireSize = QueuedSize - (TotalDownloadSize + CurrentDownloadSize);
            int RequireSeconds = (int)Math.Ceiling(RequireSize / DownloadSpeed);

            if (RequireSeconds < 0) RequireSeconds = 0;

            if (RequireSeconds < 60)
            {
                return "약 " + RequireSeconds + "초 남음";
            }
            else if (RequireSeconds < 3600)
            {
                return "약 " + (RequireSeconds / 60) + "분 남음";
            }
            else if (RequireSeconds < 86400)
            {
                return "약 " + (RequireSeconds / 60 / 60) + "시간 남음";
            }
            else
            {
                return "남은시간 알 수 없음";
            }
        }

        public string CalculateByte(long b)
        {
            if (b < 1024 * 1024)
            {
                return (b / 1024d).ToString("0.00 KB");
            }
            else if (b < 1024 * 1024 * 1024)
            {
                return (b / 1024d / 1024d).ToString("0.00 MB");
            }
            else if (b < 1024 * 1024 * 1024 * 1024L)
            {
                return (b / 1024d / 1024d / 1024d).ToString("0.00 GB");
            }
            else
            {
                return (b / 1024d / 1024d / 1024d / 1024d).ToString("0.00 TB");
            }
        }
#endregion
        #region /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/|       EVENTHANDLER       |/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
        public event EventHandler StartDownloading;
        protected virtual void OnStartDownloading(EventArgs e)
        {
            StartDownloading?.Invoke(this, e);
        }

        public event EventHandler StartSingleFileDownload;
        protected virtual void OnStartSingleFileDownload(EventArgs e)
        {
            StartSingleFileDownload?.Invoke(this, e);
        }

        public event EventHandler SingleFileComplete;
        protected virtual void OnSingleFileComplete(EventArgs e)
        {
            SingleFileComplete?.Invoke(this, e);
        }

        public event EventHandler FileDownloadSizeChanged;
        protected virtual void OnFileDownloadSizeChanged(EventArgs e)
        {
            FileDownloadSizeChanged?.Invoke(this, e);
        }

        public event EventHandler FileDownloadEnd;
        protected virtual void OnFileDownloadEnded(EventArgs e)
        {
            FileDownloadEnd?.Invoke(this, e);
        }

        public event EventHandler CalculateBPS;
        protected virtual void OnCalculateBPS(EventArgs e)
        {
            CalculateBPS?.Invoke(this, e);
        }
        #endregion
    }
}
