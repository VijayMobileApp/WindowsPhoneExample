using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ReactiveUI;
using System.Collections.ObjectModel;
using NewExample.Model;
using System.Xml.Linq;
using ReactiveUI.Xaml;

namespace NewExample.ViewModel
{
    public class ListBoxEventsViewModel : ReactiveObject
    {
        public static ObservableCollection<ListBoxEventsModel> _StudentDetails;
        public ObservableCollection<ListBoxEventsModel> StudentDetails
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
        public ReactiveAsyncCommand addPerson { get; set; }
        public ReactiveAsyncCommand testingButton { get; set; }

        
        XDocument myData = XDocument.Load("Student.xml");

        public ListBoxEventsViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<ListBoxEventsModel>();
                StudentDetails = ListBoxEventsModel.extract(myData.ToString());
                imagePath = "/NewExample;component/Images/icon_increase.png";
            });
            getOrgDetails.Execute(true);


            testingButton = new ReactiveAsyncCommand();
            testingButton.Subscribe(x =>
            {
                MessageBox.Show("List Button Selected");
            });

            addPerson = new ReactiveAsyncCommand();
            addPerson.Subscribe(x=>{
                MessageBox.Show("Test Button Selected..");
                Constants.buttonSelected = false;
            });
        }
    }
}
