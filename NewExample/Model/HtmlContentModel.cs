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
    public class HtmlContentModel
    {
        public string formHeader { get; set; }
        public string formData { get; set; }

        public static ObservableCollection<HtmlContentModel> extract(string result)
        {
            HtmlContentModel lgp = new HtmlContentModel();
            ObservableCollection<HtmlContentModel> content = new ObservableCollection<HtmlContentModel>();
            XDocument xdoc = XDocument.Parse(result);
            //Console.WriteLine("Input Elemen==>" + xdoc.Document);
            var GetIdentityFormResponse = from ack in xdoc.Descendants("html")
                                          select ack;
            lgp.formData = GetIdentityFormResponse.ElementAt(0).ToString();
            content.Add(lgp);
                lgp = new HtmlContentModel();
           
            return content;
        }

    }
}
