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

namespace NewExample.Views
{
    public partial class ListBoxExample : PhoneApplicationPage
    {
        public ListBoxExample()
        {
            InitializeComponent();
            listBoxExample.DataContext = new ListBoxExampleViewModel();
        }

        private void ManipulationStart(object sender, ManipulationStartedEventArgs e)
        {
            ((UIElement)sender).RenderTransform = new System.Windows.Media.TranslateTransform() { X = 2, Y = 2 };
        }


        private void ManipulationComplet(object sender, ManipulationCompletedEventArgs e)
        {
            ((UIElement)sender).RenderTransform = null;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Hai");
        }

   
    }
}