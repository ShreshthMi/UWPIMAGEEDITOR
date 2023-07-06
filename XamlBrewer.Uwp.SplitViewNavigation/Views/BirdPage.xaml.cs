using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Mvvm.Services;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using System;
using Microsoft.Toolkit.Uwp.UI.Controls;

namespace XamlBrewer.Uwp.SplitViewNavigation
{
    public sealed partial class BirdPage : Page
    {
        public BirdPage()
        {
            this.InitializeComponent();
        }
        

        private async void Cropbutton_Click(object sender, RoutedEventArgs e)
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
                // Load the image from the selected file
                WriteableBitmap bitmapImage = new WriteableBitmap(1,1);
                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    await bitmapImage.SetSourceAsync(stream);
                }

                cropArea.Source = bitmapImage;
                //await cropArea.LoadImageFromFile(file);

                // Show the image crop functions

                //cropText.Visibility = Visibility.Collapsed;
                cropButtonMain.Visibility = Visibility.Collapsed;
                //cropImage.Visibility = Visibility.Visible;
                aspectRatio.Visibility = Visibility.Visible;
                cropArea.Visibility = Visibility.Visible;                
                cropButton.Visibility = Visibility.Visible;
                cancelButton.Visibility = Visibility.Visible;


                // Implement your logic to enable and display the necessary UI elements for image cropping
            }
        }

        private void Crop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            cropButtonMain.Visibility = Visibility.Visible;
            //cropText.Visibility = Visibility.Visible;
            //cropImage.Visibility = Visibility.Collapsed;
            cropArea.Visibility = Visibility.Collapsed;
            cropButton.Visibility = Visibility.Collapsed;
            cancelButton.Visibility = Visibility.Collapsed;
        }

        private void aspectRatio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
