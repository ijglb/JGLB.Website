using Blazorise;
using Blazorise.Providers;

namespace JGLB.Website.BlazoriseExt
{
    class MyIconProvider : BaseIconProvider
    {
        internal static BaseIconProvider MaterialIconProvider { get; set; } = null;
        internal string Provider { get; set; } = "Material";
        internal const string Material = "Material";
        internal const string MyIconfont = "MyIconfont";

        public override bool IconNameAsContent => true;

        public static readonly string MyIconClass = "jglb-iconfont";

        private static string[] styles = new string[]
        {
            "material-icons",
            "material-icons-outlined",
            "material-icons-outlined",
            "material-icons-two-tone",
            "material-icons-round",
            MyIconClass
        };

        public override string IconSize(IconSize iconSize)
        {
            return MaterialIconProvider.IconSize(iconSize);
        }

        public override string GetIconName(IconName name, IconStyle style)
        {
            return MaterialIconProvider.GetIconName(name, style);
        }

        public override void SetIconName(IconName name, string newName)
        {
            MaterialIconProvider.SetIconName(name, newName);
        }

        public override string GetStyleName(IconStyle iconStyle)
        {
            switch (Provider)
            {
                case Material: return MaterialIconProvider.GetStyleName(iconStyle);
                case MyIconfont: return $"{MyIconClass} material-icons";
                default: return MaterialIconProvider.GetStyleName(iconStyle);
            }
        }

        protected override bool ContainsStyleName(string iconName)
        {
            return iconName.Split(' ').Any(x => styles.Contains(x));
        }
    }
}
