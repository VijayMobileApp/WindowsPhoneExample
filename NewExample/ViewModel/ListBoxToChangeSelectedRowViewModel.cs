using System;
using ReactiveUI;
using System.Collections.ObjectModel;
using NewExample.Model;
using System.Xml.Linq;
using GalaSoft.MvvmLight.Command;
using ReactiveUI.Xaml;
namespace NewExample.ViewModel
{
    public class ListBoxToChangeSelectedRowViewModel : ReactiveObject
    {
        public static ObservableCollection<ListBoxToChangeSelectedRowModel> _StudentDetails;
        public ObservableCollection<ListBoxToChangeSelectedRowModel> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }

        public static ObservableCollection<ListBoxToChangeSelectedRowModel> _testStudentDetails;
        public ObservableCollection<ListBoxToChangeSelectedRowModel> testStudentDetails
        {
            get { return _testStudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.testStudentDetails, value); }
        }

        XDocument myData = XDocument.Load("Student.xml");

        public RelayCommand<ListBoxToChangeSelectedRowModel> ItemSelectedCommand { get; private set; }

        public ListBoxToChangeSelectedRowViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                subscribe();
            });
            getOrgDetails.Execute(true);
            ItemSelectedCommand = new RelayCommand<ListBoxToChangeSelectedRowModel>(ItemSelected);
        }

        private void ItemSelected(ListBoxToChangeSelectedRowModel myItem)
        {
            if (null != myItem)
            {
                for (int i = 0; i < StudentDetails.Count; i++)
                {
                    if (StudentDetails[i] == myItem)
                    {
                        StudentDetails[i].buttonImage = "/NewExample;component/Images/icon_increase.png";
                    }
                    else
                        StudentDetails[i].buttonImage = "/NewExample;component/Images/icon_decrease.png";
                }
                testStudentDetails = StudentDetails;
                StudentDetails = new ObservableCollection<ListBoxToChangeSelectedRowModel>();
                StudentDetails = testStudentDetails;
            }
        }
        void subscribe()
        {
            StudentDetails = new ObservableCollection<ListBoxToChangeSelectedRowModel>();
            StudentDetails = ListBoxToChangeSelectedRowModel.extract(myData.ToString());
        }
    }
}
