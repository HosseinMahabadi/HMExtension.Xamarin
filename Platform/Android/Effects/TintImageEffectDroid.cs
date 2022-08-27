using System.ComponentModel;
using System.Linq;
using Android.Graphics;
using Android.Widget;
using Java.Lang;
using Xamarin.Forms.Platform.Android;
using HMExtension.Xamarin;
using CrossPlatformEffect = HMExtension.Xamarin.TintImageEffect;
using XF = Xamarin.Forms;

[assembly: XF.ResolutionGroupName(CrossPlatformEffect.GroupName)]
[assembly: XF.ExportEffect(typeof(HMExtension.Xamarin.Platform.Android.Effects.TintImageEffectDroid), nameof(TintImageEffect))]

namespace HMExtension.Xamarin.Platform.Android.Effects
{
    public class TintImageEffectDroid : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                CrossPlatformEffect effect = (CrossPlatformEffect)Element.Effects.FirstOrDefault(e => e is CrossPlatformEffect);

                if (effect != null)
                {
                    if (Control is ImageView image)
                    {
                        var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                        image.SetColorFilter(filter);
                    }
                    else if (Control is ImageButton imageButton)
                    {
                        var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                        imageButton.SetColorFilter(filter);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred when setting the {typeof(TintImageEffect)} effect: {ex.Message}\n{ex.StackTrace}");
            }
        }

        protected override void OnDetached()
        {
        }
    }

}