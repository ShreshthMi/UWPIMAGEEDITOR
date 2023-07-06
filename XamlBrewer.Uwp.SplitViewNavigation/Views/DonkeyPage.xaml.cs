using Windows.UI.Xaml.Controls;
using Mvvm.Services;

namespace XamlBrewer.Uwp.SplitViewNavigation
{
    public sealed partial class DonkeyPage : Page
    {
        public DonkeyPage()
        {
            this.InitializeComponent();

            // To test the unregistration of the handler.
            Navigation.EnableBackButton();
        }

        private void FilterButton_OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
