namespace Aliapoh.Overlays.IPlugin
{
    public interface IPlugin
    {
        /// <summary>
        /// Return Plugin name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Return Author name.
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Setting overlay JS with identifier function name.
        /// </summary>
        string JavascriptFunctionName { get; }

        /// <summary>
        /// Plugin Version
        /// </summary>
        string Version { get; }

        /// <summary>
        /// If you using camelcase return this value "true"
        /// </summary>
        bool CamelCase { get; }

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="form"></param>
        void Initializer(OverlayForm form);
    }
}