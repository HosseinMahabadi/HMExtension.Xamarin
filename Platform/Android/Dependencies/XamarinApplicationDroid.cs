using System;
using System.Collections.Generic;
using System.Text;
using HMExtension.Xamarin.Platform.Android.Dependencies;
using HMExtension.Xamarin;
using Android.Widget;
using Android.Content.PM;
using Android.App;
using XF = Xamarin.Forms;

[assembly: XF.Dependency(typeof(XamarinApplicationDroid))]
namespace HMExtension.Xamarin.Platform.Android.Dependencies
{
    public class XamarinApplicationDroid : IXamarinApplication
    {
        PackageInfo _appInfo;
        public XamarinApplicationDroid()
        {
            var context = Application.Context;
            _appInfo = context.PackageManager.GetPackageInfo(context.PackageName, 0);
        }
        public string GetVersionNumber()
        {
            return _appInfo.VersionName;
        }

        [Obsolete]
        public string GetBuildNumber()
        {
            return _appInfo.VersionCode.ToString();
        }

        [Obsolete]
        public void Exit()
        {
            var activity = (Activity)XF.Forms.Context;
            activity.FinishAffinity();
        }

        public static AndroidX.AppCompat.View.ActionMode LastActionMode { get; set; }

        public void CloseLastContextMenu()
        {
            LastActionMode?.Finish();
        }

        public void ShowShortToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
        public void ShowLongToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}
