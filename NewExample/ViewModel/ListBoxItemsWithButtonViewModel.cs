using System;
using ReactiveUI;
using NewExample.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;
using GalaSoft.MvvmLight.Command;
using ReactiveUI.Xaml;
namespace NewExample.ViewModel
{
    public class ListBoxItemsWithButtonViewModel : ReactiveObject
    {
        public static ObservableCollection<ListBoxItemsWithButtonModel> _StudentDetails;
        public ObservableCollection<ListBoxItemsWithButtonModel> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }
        public static string _imagePath;
        public string imagePath
        {
            get { return _imagePath; }
            set { this.RaiseAndSetIfChanged(x => x.imagePath, value); }
        }

        public static ListBoxItemsWithButtonModel _SelectedItem;
        public ListBoxItemsWithButtonModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.SelectedItem, value);
                MessageBox.Show(SelectedItem.FirstName);
            }
        }


        XDocument myData = XDocument.Load("Student.xml");

        public RelayCommand<ListBoxItemsWithButtonModel> ItemSelectedCommand { get; private set; }
        public RelayCommand<ListBoxItemsWithButtonModel> ListItemSelectedCommand { get; private set; }


        public ListBoxItemsWithButtonViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<ListBoxItemsWithButtonModel>();
                StudentDetails = ListBoxItemsWithButtonModel.extract(myData.ToString());
                imagePath = "/NewExample;component/Images/icon_increase.png";

            });
            getOrgDetails.Execute(true);

            ItemSelectedCommand = new RelayCommand<ListBoxItemsWithButtonModel>(ItemSelected);
            ListItemSelectedCommand = new RelayCommand<ListBoxItemsWithButtonModel>(ListItemSelected);
        }

        private void ItemSelected(ListBoxItemsWithButtonModel myItem)
        {
            if (null != myItem)
                MessageBox.Show("Button Name==>" + myItem.FirstName);
        }

        private void ListItemSelected(ListBoxItemsWithButtonModel myItem)
        {
            if (null != myItem)
                MessageBox.Show("List Name==>" + myItem.LastName);
        }
    }
}
