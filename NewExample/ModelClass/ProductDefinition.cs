using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class ProductDefinition
    {
        public static string _language;
        public string language
        {
            get { return _language; }
            set { _language = value; }
        }

        public static string _languageDesc;
        public string languageDesc
        {
            get { return _languageDesc; }
            set { _languageDesc = value; }
        }

        public static string _fullName;
        public string fullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public static string _shortName;
        public string shortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        public static string _desc;
        public string desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public static List<ProductLink> _links;
        public List<ProductLink> links
        {
            get { return _links; }
            set { _links = value; }
        }

        public static List<String> _keywords;
        public List<String> keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        public static List<Feature> _features;
        public List<Feature> features
        {
            get { return _features; }
            set { _features = value; }
        }

        public static ProductDefinition extract(string productInfo)
        {
            String[] searchTags = { "ProductLanguage", "ProductLanguageDesc", "ProductFullName", "ProductShortName", "ProductDesc" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            ProductDefinition product = new ProductDefinition();
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

            product.language = result.ElementAt(0);
            product.languageDesc = result.ElementAt(1);
            product.fullName = result.ElementAt(2);
            product.shortName = result.ElementAt(3);
            product.desc = result.ElementAt(4);


            var productLinks = from ack in xdoc.Descendants("ProductLinks")
                               select ack;

            var productKeywords = from ack in xdoc.Descendants("ProductKeywords")
                                  select ack;

            var features = from ack in xdoc.Descendants("Features")
                           select ack;

            var feature = from ack in xdoc.Descendants("Feature")
                           select ack;

            product.links = new List<ProductLink>();
            if (productLinks.Count() > 0)
            {
                for (int i = 0; i < productLinks.Count(); i++)
                    product.links.Add(ProductLink.extract(productLinks.ElementAt(i).ToString()));
            }

            if (productKeywords.Count() > 0)
            {
                for (int i = 0; i < productKeywords.Count(); i++)
                {
                    //product.keywords.Add(Feature.extract(features.ElementAt(i).ToString()));
                }

            }

            product.features = new List<Feature>();
            if (feature.Count() > 0)
            {
                for (int i = 0; i < feature.Count(); i++)
                {
                    product.features.Add(Feature.extract(feature.ElementAt(i).ToString()));
                }
            }

            return product;
        }
    }
}
