
using NewExample.ViewModel;
using Microsoft.Phone.Controls;
using System.Windows.Controls;
using System.Windows;
using NewExample.Model;
namespace NewExample.Views
{
    public partial class ListBoxWithButton : PhoneApplicationPage
    {
        public ListBoxWithButton()
        {
            InitializeComponent();
            ListBoxWithButtonUIContainer.DataContext = new ListBoxWithButtonViewModel();
            
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button myButton = sender as Button;
            ListBoxWithButtonModel dataObject = myButton.DataContext as ListBoxWithButtonModel;
            int index = MyListBox.Items.IndexOf(dataObject);
            MessageBox.Show("Button Clicked" + dataObject.FirstName);
            
        }
    }
}