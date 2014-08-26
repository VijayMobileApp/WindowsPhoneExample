
using Microsoft.Phone.Controls;
using NewExample.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace NewExample.Views
{
    public partial class CountTheText : PhoneApplicationPage
    {
        public CountTheText()
        {
            InitializeComponent();
            this.DataContext = new CountTheTextViewModel();
        }

        private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }
    }
}