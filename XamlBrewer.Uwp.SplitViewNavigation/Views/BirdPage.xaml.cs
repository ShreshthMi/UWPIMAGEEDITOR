using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.Storage.Pickers;
using Windows.Storage;

using System;
using Microsoft.Toolkit.Uwp.UI.Controls;

using Windows.UI.Xaml.Media;
using XamlBrewer.Uwp.SplitViewNavigation.Tools;

using System.Collections.Generic;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;

namespace XamlBrewer.Uwp.SplitViewNavigation
{
    public sealed partial class BirdPage : Page
    {
        private ImageCropperHelper _cropperHelper;
        private WriteableBitmap croppedImage;
        private WriteableBitmap writeableBitmapImage;
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
                // Load the image from the selected file -- Dynamically generate the writeable bitmap with exact dimensions as our image. 

                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                    writeableBitmapImage = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
                    await writeableBitmapImage.SetSourceAsync(stream);
                }

                //cropArea.Source = writeableBitmapImage; Not required as we can bind the ImageCropperControl in TwoWay mode with MainImage ImageControl.


                MainImage.Source = writeableBitmapImage;



                // Show the image crop functions

                //cropText.Visibility = Visibility.Collapsed;
                cropButtonMain.Visibility = Visibility.Collapsed;
                MainImage.Visibility = Visibility.Visible;
                MainAreaGrid.Visibility = Visibility.Visible;

                cropButton.Visibility = Visibility.Visible;
                cancelButton.Visibility = Visibility.Visible;
                buttonbargrid.Visibility = Visibility.Visible;


                // Implement your logic to enable and display the necessary UI elements for image cropping
            }
        }



        private async void Crop_ClickAsync(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;  // Set the initial location to the Pictures Library
            savePicker.DefaultFileExtension = ".png";  // Set the default file extension
            savePicker.SuggestedFileName = "cropped_image";  // Set the default file name

            savePicker.FileTypeChoices.Add("PNG Image", new List<string> { ".png" });  // Specify the supported file types

            StorageFile file = await savePicker.PickSaveFileAsync();  // Show the file save picker

            if (file != null)
            {
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await cropArea.SaveAsync(fileStream, BitmapFileFormat.Png);  // Save the cropped area to the file stream
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainImage.RenderTransform = null;
            MainImage.Source = null;


            cropButtonMain.Visibility = Visibility.Visible;

            MainImage.Visibility = Visibility.Collapsed;
            cropArea.Visibility = Visibility.Collapsed;
            cropButton.Visibility = Visibility.Collapsed;
            cancelButton.Visibility = Visibility.Collapsed;
            buttonbargrid.Visibility = Visibility.Collapsed;
            MainAreaGrid.Visibility = Visibility.Collapsed;
        }


        private void RotateLeft(object sender, RoutedEventArgs e)
        {

            //CaptureRotatedImage(currentRotationAngle);
            writeableBitmapImage = writeableBitmapImage.Rotate(270);
            MainImage.Source = writeableBitmapImage;

        }



        private void RotateRight(object sender, RoutedEventArgs e)
        {
            writeableBitmapImage = writeableBitmapImage.Rotate(90);

            MainImage.Source = writeableBitmapImage;
        }

        private void MirrorClick(object sender, RoutedEventArgs e)
        {
            writeableBitmapImage = writeableBitmapImage.Flip(WriteableBitmapExtensions.FlipMode.Vertical);

            MainImage.Source = writeableBitmapImage;
        }

        private void FlipClick(object sender, RoutedEventArgs e)
        {
            writeableBitmapImage = writeableBitmapImage.Flip(WriteableBitmapExtensions.FlipMode.Horizontal);

            MainImage.Source = writeableBitmapImage;
        }

        private void AspectRatio(object sender, RoutedEventArgs e)
        {
            cropArea.Visibility = Visibility.Visible;

            MainImage.Visibility = Visibility.Collapsed;
        }


        //Not using CaptureRotatedImage method as it is rotating UIElement and requires further code to extract writeablebitmap with its parent Element's rotateTransform intact 
        private void CaptureRotatedImage(double currentRotationAngle)
        {
            RotateTransform rotateTransform = new RotateTransform
            {
                Angle = currentRotationAngle,
                CenterX = MainImage.ActualWidth / 2,
                CenterY = MainImage.ActualHeight / 2
            };

            MainImage.RenderTransform = rotateTransform;
            cropArea.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
            cropArea.RenderTransform = new RotateTransform { Angle = currentRotationAngle };
        }
    }
}
