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
    public class TestViewModel : ReactiveObject
    {
        public static ObservableCollection<TestModel> _StudentDetails;
        public ObservableCollection<TestModel> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }

        XDocument myData = XDocument.Load("Student.xml");
        
         public TestViewModel()
         {
             var getOrgDetails = new ReactiveAsyncCommand();

             getOrgDetails.Subscribe(x =>
             {
                 StudentDetails = new ObservableCollection<TestModel>();
                 StudentDetails = TestModel.extract(myData.ToString());
             });
             getOrgDetails.Execute(true);
         }

    }
}
