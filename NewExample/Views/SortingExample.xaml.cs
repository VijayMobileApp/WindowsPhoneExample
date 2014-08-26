using NewExample.ViewModel;
using Microsoft.Phone.Controls;
using System.Windows.Controls;
using System.Windows.Data;

namespace NewExample.Views
{
    public partial class SortingExample : PhoneApplicationPage
    {
        public SortingExample()
        {
            InitializeComponent();
            this.DataContext = new SortingExampleViewModel();
        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }
    }
}