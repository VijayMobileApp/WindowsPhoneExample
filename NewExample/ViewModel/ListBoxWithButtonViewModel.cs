using System;
using ReactiveUI;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using NewExample.Model;
using ReactiveUI.Xaml;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using GalaSoft.MvvmLight.Command;
namespace NewExample.ViewModel
{
    public class ListBoxWithButtonViewModel : ReactiveObject
    {
        public static ObservableCollection<ListBoxWithButtonModel> _StudentDetails;
        public ObservableCollection<ListBoxWithButtonModel> StudentDetails
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

        public static ListBoxWithButtonModel _SelectedItem;
        public ListBoxWithButtonModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.SelectedItem, value);
                MessageBox.Show(SelectedItem.FirstName);
            }
        }

        XDocument myData = XDocument.Load("Student.xml");

        public RelayCommand<ListBoxWithButtonModel> ItemSelectedCommand { get; private set; }

        public ListBoxWithButtonViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                subscribe();

            });
            getOrgDetails.Execute(true);
            ItemSelectedCommand = new RelayCommand<ListBoxWithButtonModel>(ItemSelected);
        }

        private void ItemSelected(ListBoxWithButtonModel myItem)
        {
            if (null != myItem)
            {
                MessageBox.Show("Name==>" + myItem.index);
                StudentDetails.Remove(myItem);
            }
        }

        void subscribe()
        {
            StudentDetails = new ObservableCollection<ListBoxWithButtonModel>();
            StudentDetails = ListBoxWithButtonModel.extract(myData.ToString());
        }
    }
}
