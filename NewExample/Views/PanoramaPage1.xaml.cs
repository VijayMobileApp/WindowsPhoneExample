using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Text;

namespace NewExample.Views
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        public PanoramaPage1()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            System.Uri myUri = new System.Uri("http://gmail.com/");
            HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), myRequest);
        }

        void GetRequestStreamCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
            // End the stream request operation
            Stream postStream = myRequest.EndGetRequestStream(callbackResult);

            // Create the post data
            string postData = "param1=value1&param2=value2";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Add the post data to the web request
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

            // Start the web request
            myRequest.BeginGetResponse(new AsyncCallback(GetResponsetStreamCallback), myRequest);
        }

        void GetResponsetStreamCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = httpWebStreamReader.ReadToEnd();
                //For debug: show results
                Console.WriteLine("Result==>"+result);
            }
        }
    }
}