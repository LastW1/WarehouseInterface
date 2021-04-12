using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WarehouseInterface.Managers
{
    public static class ImageManager
    {
        public static byte[] ImageToByte(Image image)
        {
            if (image.Source == null)
            {
                return null;
            }

            var imagePath = image.Source.ToString().Replace("file:///", "");

            return File.ReadAllBytes(imagePath);
        }

        public static bool OnClickImageLoad(ref Image image)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };


            bool? response = dialog.ShowDialog();

            if (response == true)
            {
                string filePath = dialog.FileName;

                image.Source = new BitmapImage(new Uri(filePath));

                return true;
            }

            return false;
        }

        public static BitmapImage ByteToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
