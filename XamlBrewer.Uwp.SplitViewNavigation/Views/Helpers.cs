using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace XamlBrewer.Uwp.SplitViewNavigation
{
    internal static class Helpers
    {

        private static async Task<WriteableBitmap> LoadAsync(
            this WriteableBitmap writeableBitmap,
            StorageFile storageFile)
        {
            var wb = writeableBitmap;

            using (var stream = await storageFile.OpenReadAsync())
            {
                await wb.SetSourceAsync(stream);
            }

            return wb;
        }
    }
}