using System;
using System.Collections.Generic;
using System.Text;

namespace HMExtension.Xamarin
{
    public interface IXamarinApplication
    {
        void ShowShortToast(string message);
        void ShowLongToast(string message);
        string GetVersionNumber();
        string GetBuildNumber();
        void Exit();
        void CloseLastContextMenu();
    }
}
