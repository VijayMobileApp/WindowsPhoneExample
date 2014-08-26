using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;
using ReactiveUI.Xaml;
using ReactiveUI;
using System.Xml.Linq;
using NewExample.Model;
using System.Collections.ObjectModel;

namespace NewExample.ViewModel
{
    public class HtmlContentViewModel : ReactiveObject
    {
        public static ObservableCollection<HtmlContentModel> _webDetails;
        public ObservableCollection<HtmlContentModel> webDetails
        {
            get { return _webDetails; }
            set { this.RaiseAndSetIfChanged(x => x.webDetails, value); }
        }

        public static string _htmlContent;
        public string htmlContent
        {
            get { return _htmlContent; }
            set { this.RaiseAndSetIfChanged(x => x.htmlContent, value); }
        }

        public static string _webSource;
        public string webSource
        {
            get { return _webSource; }
            set { this.RaiseAndSetIfChanged(x => x.webSource, value); }
        }

        XDocument myData = XDocument.Load("WebXML.xml");
        public HtmlContentViewModel()
        {

            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                webDetails = new ObservableCollection<HtmlContentModel>();
                webDetails = HtmlContentModel.extract(myData.ToString());
                htmlContent = webDetails[0].formData;
                //Console.WriteLine("Result String==>" + htmlContent);
                SaveHelpFileToIsoStore();
                webSource = ("Help.htm");//D:\Vijay\Example\My try\NewExample\Constants\HtmlContent.xml

            });
            getOrgDetails.Execute(true);
        }

        private void SaveHelpFileToIsoStore()
        {
            string strFileName = "Help.htm";
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            //remove the file if exists to allow each run to independently write to
            // the Isolated Storage
            if (isoStore.FileExists(strFileName) == true)
            {
                isoStore.DeleteFile(strFileName);
                MessageBox.Show("Old file is deleted..");
              
            }
            else
                MessageBox.Show("There is no old file..");

            using (var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            using (var fileStream = new IsolatedStorageFileStream("Help.htm", FileMode.Create, myIsolatedStorage))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(htmlContent);
            }

            //IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication();
            //IsolatedStorageFileStream FS = ISF.OpenFile("Help.htm", FileMode.Open, FileAccess.Read);
            //using (StreamReader SR = new StreamReader(FS))
            //{
            //    Console.WriteLine("Result==>" + SR.ReadLine());
            //}

            //IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            ////remove the file if exists to allow each run to independently write to
            //// the Isolated Storage
            //if (isoStore.FileExists(strFileName) == true)
            //{
            //    isoStore.DeleteFile(strFileName);
            //    MessageBox.Show("Old file is deleted..");
            //}
            //else
            //    MessageBox.Show("There is no Old file..");

            //StreamResourceInfo sr = Application.GetResourceStream(new Uri(strFileName, UriKind.Relative));
            //using (BinaryReader br = new BinaryReader(sr.Stream))
            //{
            //    byte[] data = br.ReadBytes((int)sr.Stream.Length);
            //    //save file to Isolated Storage
            //    using (BinaryWriter bw = new BinaryWriter(isoStore.CreateFile(strFileName)))
            //    {
            //        bw.Write(data);
            //        bw.Close();
            //    }
            //}
        }
    }
}
