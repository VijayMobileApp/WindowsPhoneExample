using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class FeatureBasic
    {
        public string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string _value;
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string _valueDesc;
        public string valueDesc
        {
            get { return _valueDesc; }
            set { _valueDesc = value; }
        }



        public static FeatureBasic extract(string productInfo)
        {
            String[] searchTags = { "FeatureID", "FeatureValue", "FeatureValueDesc" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            FeatureBasic product = new FeatureBasic();
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
            product.id = result.ElementAt(0);
            product.value = result.ElementAt(1);
            product.valueDesc = result.ElementAt(2);
            return product;
        }
    }
}
