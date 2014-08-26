using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class Feature
    {
        public string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int _type;
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String _masterType;
        public String masterType
        {
            get { return _masterType; }
            set { _masterType = value; }
        }

        public bool _mandotory;
        public bool mandotory
        {
            get { return _mandotory; }
            set { _mandotory = value; }
        }

        public bool _selectable;
        public bool selectable
        {
            get { return _selectable; }
            set { _selectable = value; }
        }

        public bool _beno;
        public bool beno
        {
            get { return _beno; }
            set { _beno = value; }
        }

        public int _orderNo;
        public int orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public String _thumbnail;
        public String thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; }
        }

        public List<FeatureDefinition> _definitions;
        public List<FeatureDefinition> definitions
        {
            get { return _definitions; }
            set { _definitions = value; }
        }

        public static List<FeatureDefinition> test = new List<FeatureDefinition>();

        public static Feature extract(string productInfo)
        {
            String[] searchTags = { "FeatureID", "FeatureType", "FeatureMasterType", "FeatureMandatory", "FeatureSelectable", "FeatureIsBeno", "FeatureOrderNo", "FeatureThumbnail" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            Feature feature = new Feature();
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

            feature.id = result.ElementAt(0);
            feature.type = int.Parse(result.ElementAt(1));
            feature.masterType = result.ElementAt(2);
            feature.mandotory = bool.Parse(result.ElementAt(3));
            feature.selectable = bool.Parse(result.ElementAt(4));
            feature.beno = bool.Parse(result.ElementAt(5));
            feature.orderNo = int.Parse(result.ElementAt(6));
            feature.thumbnail = result.ElementAt(7);


            var featureDefinitions = from ack in xdoc.Descendants("FeatureDefinitions")
                                     select ack;

            feature.definitions = new List<FeatureDefinition>();
            if (featureDefinitions.Count() > 0)
            {
                for (int i = 0; i < featureDefinitions.Count(); i++)
                {
                    test.Add(FeatureDefinition.extract(featureDefinitions.ElementAt(i).ToString()));
                }
            }
            feature.definitions.AddRange(test);
            return feature;
        }

    }
}
