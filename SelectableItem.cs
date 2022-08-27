using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HMExtension.Xamarin
{
    public class SelectableItem<T> : ViewModelBase
    {
        public SelectableItem()
        {
            /*Application.Current.RequestedThemeChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(TextColor));
            };*/
        }

        public Color DarkColor { get; set; } = Color.WhiteSmoke;
        public Color LightColor { get; set; } = Color.FromHex("#232323");
        public Color SelectedDarkColor { get; set; } = Color.DarkOrange;
        public Color SelectedLightColor { get; set; } = Color.FromHex("#fee440");
        private bool IsSelected { get; set; } = false;

        private T _title;
        public T Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public Color TextColor
        {
            get
            {
                if (IsSelected)
                {
                    return GetBasedOnTheme(SelectedDarkColor, SelectedLightColor);
                }
                else
                {
                    return GetBasedOnTheme(DarkColor, LightColor);
                }
            }
        }

        private double _scale = 1;
        public double Scale
        {
            get => _scale;
            set => SetProperty(ref _scale, value);
        }

        public void Select()
        {
            IsSelected = true;
            Scale = 1.5;
            OnPropertyChanged(nameof(TextColor));
        }

        public void UnSelect()
        {
            IsSelected = false;
            Scale = 1;
            OnPropertyChanged(nameof(TextColor));
        }
    }
}
