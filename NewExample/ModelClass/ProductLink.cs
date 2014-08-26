using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class ProductLink
    {
        public static String _title;
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }

        public static String _url;
        public String url
        {
            get { return _url; }
            set { _url = value; }
        }

        public static String _type;
        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        public static String _typeDesc;
        public String typeDesc
        {
            get { return _typeDesc; }
            set { _typeDesc = value; }
        }

        public static String _scalePage;
        public String scalePage
        {
            get { return _scalePage; }
            set { _scalePage = value; }
        }

        public static ProductLink extract(string productInfo)
        {
            String[] searchTags = { "ProductLinkTitle", "ProductLinkUrl", "ProductLinkType", "ProductLinkTypeDesc", "ScalePage" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            ProductLink proLink = new ProductLink();
            XElement idnos = null;
            for (int i = 0; i < searchTags.Length; i++)
            {
                try
                {
                    idnos = xdoc.Descendants()
                        .Where(pp => pp.Name == searchTags[i])
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    idnos = null;
                }
                finally
                {
                    result.Add(((null == idnos) || (null == idnos.Value)) ? "" : idnos.Value);
                }
            }

            proLink.title = result.ElementAt(0);
            proLink.url = result.ElementAt(1);
            proLink.type = result.ElementAt(2);
            proLink.typeDesc = result.ElementAt(3);
            proLink.scalePage = result.ElementAt(4);
            return proLink;
        }
    }
}
