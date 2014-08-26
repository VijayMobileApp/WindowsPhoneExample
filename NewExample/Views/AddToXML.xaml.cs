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
    public partial class AddToXML : PhoneApplicationPage
    {
        public AddToXML()
        {
            InitializeComponent();
            addToXMLUIContainer.DataContext = new AddToXMLViewModel();
        }
        private void ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            ((UIElement)sender).RenderTransform = new System.Windows.Media.TranslateTransform() { X = 2, Y = 2 };
        }

        private void ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            ((UIElement)sender).RenderTransform = null;
        }
    }
}