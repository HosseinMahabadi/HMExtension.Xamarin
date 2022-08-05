using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HMExtension.Xamarin.Controls.Popups
{
    public interface IPopupViewModel
    {
        ListView listView { get; set; }
        void GoToSelectedItem();
    }
}
