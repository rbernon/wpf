using System.Reflection;
using System.Resources;

namespace MS.Internal.Xaml.Srid
{
	partial class SRID
	{
		public static ResourceManager ResourceManager = new System.Resources.ResourceManager("SR", Assembly.GetExecutingAssembly());
	}
}
