using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMExtension.Xamarin
{
    [ContentProperty(nameof(ResourceName))]
    public class EmbededResourceExtension : IMarkupExtension
    {
        public string ResourceName { get; set; }
        public bool LoadFromCallingAssembly { get; set; } = true;
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(ResourceName))
            {
                return null;
            }
            else
            {
                if (LoadFromCallingAssembly)
                {
                    return ImageSource.FromResource(ResourceName, Assembly.GetCallingAssembly());
                }
                else
                {
                    return ImageSource.FromResource(ResourceName);
                }
            }
        }
    }
}
