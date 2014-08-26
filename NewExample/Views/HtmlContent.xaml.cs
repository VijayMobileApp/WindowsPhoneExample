﻿using System;
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
using NewExample.ViewModel;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;

namespace NewExample.Views
{
    public partial class HtmlContent : PhoneApplicationPage
    {
        public HtmlContent()
        {
            InitializeComponent();
            HtmlUIContainer.DataContext = new HtmlContentViewModel();
        }

        //void webBrowser1_Loaded(object sender, RoutedEventArgs e)
        //{
        //    SaveHelpFileToIsoStore();
        //    webBrowser1.Navigate(new Uri("Help.htm", UriKind.Relative));
        //}
        //private void SaveHelpFileToIsoStore()
        //{
        //    string strFileName = "Help.htm";
        //    IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();

        //    //remove the file if exists to allow each run to independently write to
        //    // the Isolated Storage
        //    if (isoStore.FileExists(strFileName) == true)
        //    {
        //        isoStore.DeleteFile(strFileName);
        //    }
        //    StreamResourceInfo sr = Application.GetResourceStream(new Uri(strFileName, UriKind.Relative));
        //    using (BinaryReader br = new BinaryReader(sr.Stream))
        //    {
        //        byte[] data = br.ReadBytes((int)sr.Stream.Length);
        //        //save file to Isolated Storage
        //        using (BinaryWriter bw = new BinaryWriter(isoStore.CreateFile(strFileName)))
        //        {
        //            bw.Write(data);
        //            bw.Close();
        //        }
        //    }
        //}
    }
}