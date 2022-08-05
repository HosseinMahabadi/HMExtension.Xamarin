using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMExtension.Xamarin.Component
{
    [ContentProperty(nameof(ResourceName))]
    public class EmbededResourceExtension : IMarkupExtension
    {
        public string ResourceName { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourceName))
            {
                return null;
            }
            else
            {
                return ImageSource.FromResource(ResourceName, 
                    Assembly.GetCallingAssembly());
            }
        }
    }
}
