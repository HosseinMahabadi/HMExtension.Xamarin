using Xamarin.Forms;
using System;
using System.Linq;

namespace HMExtension.Xamarin
{
    public class TintImageEffect : RoutingEffect
    {
        public TintImageEffect() : base($"{GroupName}.{Name}") { }

        public const string GroupName = "HM";
        public const string Name = "TintImageEffect";

        public Color TintColor { get; set; } = Color.Black;
    }
}