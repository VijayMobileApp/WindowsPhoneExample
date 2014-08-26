using System.Linq;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace NewExample.Model
{
    public class ListBoxToChangeSelectedRowModel
    {
        public string FirstName { get; set; }
        public string buttonImage { get; set; }

        public static ObservableCollection<ListBoxToChangeSelectedRowModel> extract(string result)
        {
            ListBoxToChangeSelectedRowModel lgp = new ListBoxToChangeSelectedRowModel();
            ObservableCollection<ListBoxToChangeSelectedRowModel> content = new ObservableCollection<ListBoxToChangeSelectedRowModel>();
            XDocument xdoc = XDocument.Parse(result);

            var res = from query in xdoc.Descendants("student")
                      select query;

            for (int i = 0; i < res.Count(); i++)
            {
                lgp.FirstName = res.ElementAt(i).Element("firstname").Value;
                lgp.buttonImage = "/NewExample;component/Images/icon_decrease.png";
                content.Add(lgp);
                lgp = new ListBoxToChangeSelectedRowModel();
            }
            return content;
        }
    }
}
