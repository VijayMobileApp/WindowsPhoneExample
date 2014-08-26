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
using NewExample.ViewModel;
using ReactiveUI.Xaml;
using NewExample.Model;

namespace NewExample.Views
{
    public partial class MVVMListBox : PhoneApplicationPage
    {
        public MVVMListBox()
        {
            InitializeComponent();
            MVVMListBoxUIContainer.DataContext = new MVVMListBoxViewModel();
        }

        //private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (listBox1.SelectedIndex == -1)
        //        return;

        //    ListBox listbox = (ListBox)sender;
        //    MVVMListBoxModel selStu = (MVVMListBoxModel)listbox.SelectedItem;
        //    MessageBox.Show("Selected Name==>"+selStu.FirstName);
        //    if (selStu.FirstName == "Vijay")
        //    {
        //        var rootFrame = (App.Current as App).RootFrame;
        //        rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        //    }
        //}
    }
}