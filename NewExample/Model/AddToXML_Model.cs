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
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Collections.ObjectModel;

namespace NewExample.Model
{
    public class AddToXML_Model
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string PersonImage { get; set; }

        public static ObservableCollection<AddToXML_Model> extract(string result)
        {
            AddToXML_Model lgp = new AddToXML_Model();
            ObservableCollection<AddToXML_Model> content = new ObservableCollection<AddToXML_Model>();
            XDocument xdoc = XDocument.Parse(result);

            var res = from query in xdoc.Descendants("student")
                      select query;

            for (int i = 0; i < res.Count(); i++)
            {
                lgp.FirstName = res.ElementAt(i).Element("firstname").Value;
                lgp.LastName = res.ElementAt(i).Element("lastname").Value;
                lgp.Age = res.ElementAt(i).Element("age").Value;
                lgp.PersonImage = res.ElementAt(i).Element("photo").Value;
                content.Add(lgp);
                lgp = new AddToXML_Model();
            }
            return content;

            //var data = from query in xdoc.Descendants("student")
            //           select new LoginPageModel
            //           {
            //               firstname = (string)query.Element("firstname"),
            //               lastname = (string)query.Element("lastname"),
            //               age = (int)query.Element("age")
            //           };
        }

    }
}
