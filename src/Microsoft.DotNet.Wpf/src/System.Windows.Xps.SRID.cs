using System.Reflection;

namespace System.Windows.Xps
{
    internal static partial class SRID
    {
        private static global::System.Resources.ResourceManager s_resourceManager;
        internal static global::System.Resources.ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new global::System.Resources.ResourceManager("SR", Assembly.GetExecutingAssembly()));
        internal static global::System.Globalization.CultureInfo Culture { get; set; }

        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        internal static string GetResourceString(string resourceKey, string defaultValue = null) =>  ResourceManager.GetString(resourceKey, Culture);
		}
}
