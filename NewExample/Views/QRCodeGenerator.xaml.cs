
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class QRCodeGenerator : PhoneApplicationPage
    {
        public QRCodeGenerator()
        {
            InitializeComponent();
            this.DataContext = new QRCodeGeneratorViewModel();
        }
    }
}