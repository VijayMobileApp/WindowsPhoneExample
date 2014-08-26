using Microsoft.Phone.Tasks;
using ReactiveUI;
using System;
using System.Windows.Media.Imaging;
using ZXing;
using System.Windows.Controls;
using ReactiveUI.Xaml;

namespace NewExample.ViewModel
{
    public class QRCodeGeneratorViewModel : ReactiveObject
    {
        public static string _phoneNumber;
        public string phoneNumber
        {
            get { return _phoneNumber; }
            set { this.RaiseAndSetIfChanged(x => x.phoneNumber, value); }
        }

        public static WriteableBitmap _imgQRCode;
        public WriteableBitmap imgQRCode
        {
            get { return _imgQRCode; }
            set { this.RaiseAndSetIfChanged(x => x.imgQRCode, value); }
        }

        public ReactiveAsyncCommand genarateButton { get; set; }
        public ReactiveAsyncCommand scanButton { get; set; }


        PhoneNumberChooserTask phoneNumberChooserTask;
        public QRCodeGeneratorViewModel()
        {
            phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);

            genarateButton = new ReactiveAsyncCommand();
            genarateButton.Subscribe(x =>
            {
                //imgQRCode = GenerateQRCode("9943756999");
                phoneNumberChooserTask.Show();

            });

            scanButton = new ReactiveAsyncCommand();
            scanButton.Subscribe(x =>
            {
                //D:\Vijay\Beno Windows Phone\NewExample1\NewExample\Views\QRCodeScanner.xaml
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/QRCodeScanner.xaml", UriKind.Relative));
               // rootFrame.Navigate(new Uri("Views/QRCodeScanner.xaml", UriKind.Relative));
            });
        }

        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.DisplayName = e.DisplayName;
                phoneCallTask.PhoneNumber = e.PhoneNumber;
                phoneNumber = e.PhoneNumber;
                imgQRCode = GenerateQRCode(phoneNumber);
            }
        }

        private static WriteableBitmap GenerateQRCode(string phoneNumber)
        {
            BarcodeWriter _writer = new BarcodeWriter();

            _writer.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {
                Foreground = System.Windows.Media.Color.FromArgb(0, 0, 0, 0),
            };

            _writer.Format = BarcodeFormat.QR_CODE;

            _writer.Options.Height = 400;
            _writer.Options.Width = 400;
            _writer.Options.Margin = 1;
           // var barcodeImage = _writer.Write("http://" + "http://bcgen.com/");
        
            var barcodeImage = _writer.Write("tel:" + phoneNumber);
            return barcodeImage;
        }

//          Purpose   	    Prefix	        Example
//          Website URL	    http://	    http://bcgen.com/
//          Facebook Like	http://	    http://facebook.com/IDAutomation
//          Twitter Follow	http://	    http://twitter.com/IDAutomation
//          E-mail Address	mailto:	    mailto:admin@yoursite.com
//          Phone Numbers	tel:	    tel:+18135142564
//          Text (SMS)	    sms:	    sms:12345
//          VCARD Contact   MECARD:	    MECARD:N:Smith,John;ADR:550 N. Reo St.,Suite 300,Tampa, FL33609;TEL:+18135142564;EMAIL:you@com;URL:bcgen.com
        //  Information, in 
        //  MeCard format	
    }
}
