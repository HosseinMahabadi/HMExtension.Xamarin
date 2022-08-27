using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace HMExtension.Xamarin
{
    public static class XamarinApplicationExtension
    {
        static IXamarinApplication XamarinApplication = DependencyService.Get<IXamarinApplication>();

        public static void ShowShortToast(this Application application, string message)
        {
            XamarinApplication.ShowShortToast(message);
        }

        public static void ShowLongToast(this Application application, string message)
        {
            XamarinApplication.ShowLongToast(message);
        }

        public static string GetVersionNumber(this Application application)
        {
            return XamarinApplication.GetVersionNumber();
        }

        public static string GetBuildNumber(this Application application)
        {
            return XamarinApplication.GetBuildNumber();
        }

        public static void Exit(this Application application)
        {
            XamarinApplication.Exit();
        }

        public static void CloseLastContextMenu(this Application application)
        {
            XamarinApplication.CloseLastContextMenu();
        }

        public static T GetParent<T>(this Element element) where T : Element
        {
            return element is T ? element as T : element.Parent != null ? element.Parent.GetParent<T>() : default;
        }

        public static string GetErrorMessage(this Exception ex)
        {
            return $"An error accoured in application ===> " +
                $"{ex.StackTrace}{Environment.NewLine}" +
                $"{ex.TargetSite.Name}{Environment.NewLine}" +
                $"{ex.Message}";
        }
    }
}
