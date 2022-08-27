using System;
using System.Globalization;
using Xamarin.Forms;

namespace HMExtension.Xamarin
{
    public class SelectedItemEventArgsToSelectedItemConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var eventArgs = value as SelectedItemChangedEventArgs;
			return eventArgs.SelectedItem;
		}

		[Obsolete]
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new SelectedItemChangedEventArgs(value);
		}
	}
}
