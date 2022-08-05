using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HMExtension.Xamarin
{
    internal static class Globals
    {
        public static Color LightPrimaryColor = Color.FromHex("#FF178CE9");
        public static Color DarkPrimaryColor = Color.FromHex("#FF005398");
        public static Color LightPrimaryLitColor = Color.FromHex("#3DA3F5");
        public static Color DarkPrimaryLitColor = Color.FromHex("#1E68A3");
        public static Color MainDarkColor = Color.FromHex("#232323");
        public static Color MainLightColor = Color.WhiteSmoke;
        public static Color SecondaryColor = Color.FromHex("#fee440");
        public static Color ThirdColor = Color.DarkOrange;
        public static Color CostColor = Color.FromHex("FF178CE9");
        public static Color IncomeColor = Color.FromHex("FF178CE9");
        public static Color PageTransparentColor = Color.FromHex("FF178CE9");
        public static Color MainLightColorControls = Color.FromHex("FF178CE9");
        public static Color MainLightColorSeperator = Color.FromHex("FF178CE9");
        public static Color MainDarkColorSeperator = Color.FromHex("FF178CE9");
        public static Color MainDarkColorControls = Color.FromHex("FF178CE9");
        public static Color MainDarkColorTransparent = Color.FromHex("FF178CE9");
        public static Color MainLightColorTransparent = Color.FromHex("FF178CE9");

        public static T GetParent<T>(this Element element) where T : Element
        {
            if (element is T)
            {
                return element as T;
            }
            else
            {
                if (element.Parent != null)
                {
                    return element.Parent.GetParent<T>();
                }

                return default(T);
            }
        }

        public static string GetErrorMessage(Exception ex)
        {
            return $"An error accoured in JibBan ===> " +
                $"{ex.StackTrace}{Environment.NewLine}" +
                $"{ex.TargetSite.Name}{Environment.NewLine}" +
                $"{ex.Message}";
        }
    }
}
