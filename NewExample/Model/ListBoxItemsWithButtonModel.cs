using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;
namespace NewExample.Model
{
    public class ListBoxItemsWithButtonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string PersonImage { get; set; }

        public static ObservableCollection<ListBoxItemsWithButtonModel> extract(string result)
        {
            ListBoxItemsWithButtonModel lgp = new ListBoxItemsWithButtonModel();
            ObservableCollection<ListBoxItemsWithButtonModel> content = new ObservableCollection<ListBoxItemsWithButtonModel>();
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
                lgp = new ListBoxItemsWithButtonModel();
            }
            return content;
        }
    }
}
