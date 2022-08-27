using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using HMExtension.Xamarin;
using HMExtension.Xamarin.Platform.iOS.Dependencies;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinApplicationiOS))]
namespace HMExtension.Xamarin.Platform.iOS.Dependencies
{
    public class XamarinApplicationiOS : IXamarinApplication
    {
        public string GetVersionNumber()
        {
            //var VersionNumber = NSBundle.MainBundle.InfoDictionary.ValueForKey(new NSString("CFBundleShortVersionString")).ToString();   
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
        public string GetBuildNumber()
        {
            //var BuildNumber = NSBundle.MainBundle.InfoDictionary.ValueForKey(new NSString("CFBundleVersion")).ToString();   
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }

        public void Exit()
        {
            Thread.CurrentThread.Abort();
        }

        public void CloseLastContextMenu()
        {
            //throw new NotImplementedException();
        }

        public void ShowShortToast(string message)
        {
            //throw new NotImplementedException();
        }

        public void ShowLongToast(string message)
        {
            //throw new NotImplementedException();
        }
    }
}