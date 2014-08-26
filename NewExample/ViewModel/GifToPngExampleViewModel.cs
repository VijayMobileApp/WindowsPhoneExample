using System;
using ReactiveUI;
using System.Windows.Media.Imaging;
using ImageTools.IO.Gif;
using ImageTools;
using System.IO;
using ImageTools.IO.Png;
using System.Net;
using System.Text;
using System.IO.IsolatedStorage;

namespace NewExample.ViewModel
{
    public class GifToPngExampleViewModel : ReactiveObject
    {
        public static BitmapImage bitmap;

        public static ExtendedImage _jpgImage;
        public ExtendedImage jpgImage
        {
            get { return _jpgImage; }
            set { this.RaiseAndSetIfChanged(x => x.jpgImage, value); }
        }

        public static BitmapImage _bitmapImg;
        public BitmapImage bitmapImg
        {
            get { return _bitmapImg; }
            set { this.RaiseAndSetIfChanged(x => x.bitmapImg, value); }
        }

        public GifToPngExampleViewModel()
        {
            ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            jpgImage = new ExtendedImage() { UriSource = new Uri("https://s3.amazonaws.com/crbnglobal/yapikrediworldcard.gif", UriKind.Absolute) };

            GetImage("https://s3.amazonaws.com/crbnglobal/garantiflexi.jpg");


            //var bi = new BitmapImage(new Uri("https://s3.amazonaws.com/crbnglobal/garantiflexi.jpg"));
            //jpgImage = bi;
            //ImageResponse(bi);


        }

        private void GetImage(string imageLink)
        {
            WebClient client = new WebClient();
            client.OpenReadAsync(new Uri(imageLink));
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);

        }

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("image.jpg", System.IO.FileMode.Create, file))
            {
                byte[] buffer = new byte[1024];
                while (e.Result.Read(buffer, 0, buffer.Length) > 0)
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }

            bitmapImg = GetImageFromIsolatedStorage("image.jpg");

        }

        private static BitmapImage GetImageFromIsolatedStorage(string imageName)
        {
            var bimg = new BitmapImage();
            using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = iso.OpenFile(imageName, FileMode.Open, FileAccess.Read))
                {
                    bimg.SetSource(stream);
                }
            }
            return bimg;
        }


    }
}
