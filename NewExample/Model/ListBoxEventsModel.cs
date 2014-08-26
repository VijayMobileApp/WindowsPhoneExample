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
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.Model
{
    public class ListBoxEventsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string PersonImage { get; set; }
        public string addImage { get; set; }
        

        public static ObservableCollection<ListBoxEventsModel> extract(string result)
        {
            ListBoxEventsModel lgp = new ListBoxEventsModel();
            ObservableCollection<ListBoxEventsModel> content = new ObservableCollection<ListBoxEventsModel>();
            XDocument xdoc = XDocument.Parse(result);

            var res = from query in xdoc.Descendants("student")
                      select query;
           
            for (int i = 0; i < res.Count(); i++)
            {
                lgp.FirstName = res.ElementAt(i).Element("firstname").Value;
                lgp.LastName = res.ElementAt(i).Element("lastname").Value;
                lgp.Age = res.ElementAt(i).Element("age").Value;
                lgp.PersonImage = res.ElementAt(i).Element("photo").Value;
                lgp.addImage = "/NewExample;component/Images/icon_increase.png";  
                content.Add(lgp);
                lgp = new ListBoxEventsModel();
            }
            return content;


        }
    }
}
