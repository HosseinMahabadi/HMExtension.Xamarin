using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMExtension.Xamarin.Controls.Popups
{
    public partial class PopupPage : ContentPage
    {
        public PopupPage(IPopupViewModel ViewModel)
        {
            InitializeComponent();

            ViewModel.listView = listView;
            BindingContext = ViewModel;
            ViewModel.GoToSelectedItem();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            _ = await MainGrid.FadeTo(1);
        }

        private async void ContentPage_Disappearing(object sender, EventArgs e)
        {
            _ = await MainGrid.FadeTo(0, 100);
        }
    }
}