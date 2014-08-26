using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;
using System;

namespace NewExample.Model
{
    public class LongListSelcetorExampleModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string PersonImage { get; set; }
        public int index { get; set; }
        public DateTime dateYear { get; set; }
        public string date { get; set; }
        //String.Format("{0:y}", dt);  // "March, 2008"    

        public static ObservableCollection<LongListSelcetorExampleModel> extract(string result)
        {
            LongListSelcetorExampleModel lgp = new LongListSelcetorExampleModel();
            ObservableCollection<LongListSelcetorExampleModel> content = new ObservableCollection<LongListSelcetorExampleModel>();
            XDocument xdoc = XDocument.Parse(result);

            var res = from query in xdoc.Descendants("student")
                      select query;

            for (int i = 0; i < res.Count(); i++)
            {
                lgp.FirstName = res.ElementAt(i).Element("firstname").Value;
                lgp.LastName = res.ElementAt(i).Element("lastname").Value;
                lgp.Age = res.ElementAt(i).Element("age").Value;
                lgp.PersonImage = res.ElementAt(i).Element("photo").Value;
                lgp.dateYear = DateTime.Parse(res.ElementAt(i).Element("date").Value);
                lgp.date = lgp.dateYear.ToString("y");               
                lgp.index = i;
                content.Add(lgp);
                lgp = new LongListSelcetorExampleModel();
            }
            //This is for sorting depends upon the date time
            content = new ObservableCollection<LongListSelcetorExampleModel>(from i in content orderby i.dateYear select i);
            return content;
        }
    }
}
