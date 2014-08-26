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
using System.Collections.Generic;
using NewExample.Model;
using System.Xml.Linq;
using ReactiveUI.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NewExample.ViewModel
{
    public class ListBoxExampleViewModel : ReactiveObject
    {
        public static ObservableCollection<ListBoxExampleModel> _StudentDetails;
        public ObservableCollection<ListBoxExampleModel> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }

        XDocument myData = XDocument.Load("Student.xml");

        public ListBoxExampleViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<ListBoxExampleModel>();
                StudentDetails = ListBoxExampleModel.extract(myData.ToString());

            });
            getOrgDetails.Execute(true);
        }
    }
}
