
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class PreviousDayCalculation : PhoneApplicationPage
    {
        public PreviousDayCalculation()
        {
            InitializeComponent();
            this.DataContext = new PreviousDayCalculationViewModel();
        }
    }
}