
using System.ComponentModel;

using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace XamlBrewer.Uwp.SplitViewNavigation.Tools
{
    public class ImageCropperHelper : INotifyPropertyChanged
    {
        private WriteableBitmap _mainImage;
        private WriteableBitmap _rotatedImage;

        public WriteableBitmap MainImage
        {
            get { return _mainImage; }
            set
            {
                _mainImage = value;
                OnPropertyChanged();
            }
        }

        public WriteableBitmap RotatedImage
        {
            get { return _rotatedImage; }
            set
            {
                _rotatedImage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RotateImage(WriteableBitmap image)
        {
            _rotatedImage = image;
            RotatedImage = _rotatedImage;


            // Rotate the MainImage by 90 degrees and update RotatedImage
            // Code to rotate the image goes here
            // Assign the rotated image to RotatedImage property
        }
    }
}

