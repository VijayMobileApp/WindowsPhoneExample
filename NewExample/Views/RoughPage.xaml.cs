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
using System.Windows.Data;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class RoughPage : PhoneApplicationPage
    {
        public RoughPage()
        {
            InitializeComponent();
            RoughPageUIContainer.DataContext = new RoughPageViewModel();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }
    }
}