using Mvvm.Services;
using XamlBrewer.Uwp.SplitViewNavigation;

namespace Mvvm
{
    internal class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menus
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("CropIcon"), Text = "Crop", NavigationDestination = typeof(BirdPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("FilterIcon"), Text = "Filters", NavigationDestination = typeof(DonkeyPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("WatermarkIcon"), Text = "Watermark", NavigationDestination = typeof(HorsePage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("ImageOverlayIcon"), Text = "ImageOverlay", NavigationDestination = typeof(RabbitPage) });

            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("GearIcon"), Text = "Settings", NavigationDestination = typeof(SettingsPage) });
            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("InfoIcon"), Text = "About", NavigationDestination = typeof(AboutPage) });
        }
    }
}
