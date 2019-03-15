using System;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TC3EF6.WPF.Base
{
    public static class Utility
    {
        #region "Image Stuff"
        public static ImageSource LoadImageFromResource(string ResourceName, string AssemblyName = null)
        {
            if (AssemblyName == null) AssemblyName = Assembly.GetCallingAssembly().GetName().Name;
            Uri oUri = new Uri(String.Format("pack://application:,,,/{0};component/{1}", AssemblyName, ResourceName), UriKind.RelativeOrAbsolute);
            return BitmapFrame.Create(oUri);
        }
        #endregion
    }
}
