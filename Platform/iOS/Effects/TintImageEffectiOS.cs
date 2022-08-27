using System;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using HMExtension.Xamarin;
//using HMExtension.Xamarin.Platform.iOS.Effects;
using CrossPlatformEffect = HMExtension.Xamarin.TintImageEffect;

[assembly: ResolutionGroupName(CrossPlatformEffect.GroupName)]
[assembly: ExportEffect(typeof(HMExtension.Xamarin.Platform.iOS.Effects.TintImageEffectiOS), nameof(TintImageEffect))]

namespace HMExtension.Xamarin.Platform.iOS.Effects
{
    public class TintImageEffectiOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (CrossPlatformEffect)Element.Effects.FirstOrDefault(e => e is CrossPlatformEffect);

                if (effect == null)
                    return;

                if (Control is UIImageView image)
                {
                    image.Image = image.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                    image.TintColor = effect.TintColor.ToUIColor();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred when setting the {typeof(TintImageEffectiOS)} effect: {ex.Message}\n{ex.StackTrace}");
            }
        }

        protected override void OnDetached() { }
    }
}