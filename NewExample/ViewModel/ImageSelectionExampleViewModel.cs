using System;
using ReactiveUI.Xaml;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.Phone;
using ReactiveUI;
using System.IO;

namespace NewExample.ViewModel
{
    public class ImageSelectionExampleViewModel : ReactiveObject
    {
        public static WriteableBitmap _imgSelected;
        public WriteableBitmap imgSelected
        {
            get { return _imgSelected; }
            set { this.RaiseAndSetIfChanged(x => x.imgSelected, value); }
        }

        public static WriteableBitmap _convertedImage;
        public WriteableBitmap convertedImage
        {
            get { return _convertedImage; }
            set { this.RaiseAndSetIfChanged(x => x.convertedImage, value); }
        }

        string strimage = "";

        public ReactiveAsyncCommand selectImage { get; set; }
        public ReactiveAsyncCommand convertImage { get; set; }


        public ImageSelectionExampleViewModel()
        {
            selectImage = new ReactiveAsyncCommand();
            selectImage.Subscribe(x =>
            {
                PhotoChooserTask taskToChoosePhoto = new PhotoChooserTask();
                taskToChoosePhoto.PixelHeight = 400;
                taskToChoosePhoto.PixelWidth = 400;
                taskToChoosePhoto.Show();
                taskToChoosePhoto.Completed += new EventHandler<PhotoResult>(taskToChoosePhoto_Completed);
            });

            convertImage = new ReactiveAsyncCommand();
            convertImage.Subscribe(x =>
            {
                convert64();
                convertedImage = Base64StringToBitmap(strimage);

            });
        }

        void taskToChoosePhoto_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                string fileName = e.OriginalFileName;
                WriteableBitmap selectedPhoto = PictureDecoder.DecodeJpeg(e.ChosenPhoto);
                imgSelected = selectedPhoto;

                //byte[] sbytedata = ReadToEnd(e.ChosenPhoto);
                //strimage = sbytedata.ToString();
                //Console.WriteLine("strimage 1 ==> " + strimage);
            }
        }

        void convert64()
        {
            byte[] bytearray = null;
            using (MemoryStream ms = new MemoryStream())
            {
                if (!(imgSelected == null))
                {
                    WriteableBitmap wbitmp = new WriteableBitmap((imgSelected));

                    wbitmp.SaveJpeg(ms, 40, 40, 0, 82);
                    bytearray = ms.ToArray();
                }
            }
            strimage = Convert.ToBase64String(bytearray);

        }

        WriteableBitmap Base64StringToBitmap(string base64String)
        {
            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            memoryStream.Position = 0;

            WriteableBitmap bitmapImage = new WriteableBitmap(imgSelected);
            bitmapImage.SetSource(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;
            return bitmapImage;
        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = stream.Position;
            stream.Position = 0;

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                stream.Position = originalPosition;
            }
        }
    }
}
