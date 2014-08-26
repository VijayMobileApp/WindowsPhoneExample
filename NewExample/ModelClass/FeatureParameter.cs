using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class FeatureParameter
    {
        public String _featureId;
        public String featureId
        {
            get { return _featureId; }
            set { _featureId = value; }
        }

        public String _value;
        public String value
        {
            get { return _value; }
            set { _value = value; }
        }

        public String _desc;
        public String desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public int _order;
        public int order
        {
            get { return _order; }
            set { _order = value; }
        }

        public String _thumbnail;
        public String thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; }
        }

        public double _additionalPrice;
        public double additionalPrice
        {
            get { return _additionalPrice; }
            set { _additionalPrice = value; }
        }

        public String _exchangeTypeDesc;
        public String exchangeTypeDesc
        {
            get { return _exchangeTypeDesc; }
            set { _exchangeTypeDesc = value; }
        }

        public FeatureParameter(string feaParamete)
        {
            extract(feaParamete);
        }

        public FeatureParameter()
        {

        }

        public static FeatureParameter extract(string productInfo)
        {

            String[] searchTags = { "FeatureParameterValue", "FeatureParameterDesc", "FeatureParameterOrder", "FeatureParameterThumbnail", "AdditionalPrice" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            FeatureParameter feature = new FeatureParameter();
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

            feature.value = result.ElementAt(0);
            feature.desc = result.ElementAt(1);
            feature.order = int.Parse(result.ElementAt(2));
            feature.thumbnail = result.ElementAt(3);
            if ((null != result.ElementAt(4)) && !(String.IsNullOrEmpty(result.ElementAt(4))))
            {
                feature.additionalPrice = double.Parse(result.ElementAt(4));
            }
            else
                feature.additionalPrice = 0.00;
            return feature;
        }
    }
}
