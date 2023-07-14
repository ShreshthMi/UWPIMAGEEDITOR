using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Mvvm.Services;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using System;

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

        private WriteableBitmap writeableBitmapImage;

        private async void FilterButton_OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Create a file picker instance
            FileOpenPicker filePicker = new FileOpenPicker();

            // Set file types filter
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".png");

            // Let the user pick a file
            StorageFile file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                // Load the image from the selected file -- Dynamically generate the writeable bitmap with exact dimensions as our image. 

                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                    writeableBitmapImage = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
                    await writeableBitmapImage.SetSourceAsync(stream);
                }

                FilterImage.Source = writeableBitmapImage;

                FilterButtonOpen.Visibility = Visibility.Collapsed;
                FilterImage.Visibility = Visibility.Visible;
                FilterAreaGrid.Visibility = Visibility.Visible;
                filterControlGrid.Visibility = Visibility.Visible;




            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
