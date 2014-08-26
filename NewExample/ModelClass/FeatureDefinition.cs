using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class FeatureDefinition
    {
        public String _language;
        public String language
        {
            get { return _language; }
            set { _language = value; }
        }

        public String _languageDesc;
        public String languageDesc
        {
            get { return _languageDesc; }
            set { _languageDesc = value; }
        }

        public String _title;
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String _typeDesc;
        public String typeDesc
        {
            get { return _typeDesc; }
            set { _typeDesc = value; }
        }

        public String _masterTypeDesc;
        public String masterTypeDesc
        {
            get { return _masterTypeDesc; }
            set { _masterTypeDesc = value; }
        }


        public String _value;
        public String value
        {
            get { return _value; }
            set { _value = value; }
        }

        public String _valueDesc;
        public String valueDesc
        {
            get { return _valueDesc; }
            set { _valueDesc = value; }
        }

        public List<FeatureParameter> _parameters;
        public List<FeatureParameter> parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public FeatureParameter _defaultParameter;
        public FeatureParameter defaultParameter
        {
            get { return _defaultParameter; }
            set { _defaultParameter = value; }
        }


        public static FeatureDefinition extract(string productInfo)
        {              
            String[] searchTags = { "FeatureLanguage", "FeatureLanguageDesc", "FeatureTitle", "FeatureTypeDesc", "FeatureMasterTypeDesc", "FeatureValue", "FeatureValueDesc" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            FeatureDefinition feature = new FeatureDefinition();
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

            feature.language = result.ElementAt(0);
            feature.languageDesc = result.ElementAt(1);
            feature.title = result.ElementAt(2);
            feature.typeDesc = result.ElementAt(3);
            feature.masterTypeDesc = result.ElementAt(4);
            feature.value = result.ElementAt(5);
            feature.valueDesc = result.ElementAt(6);

            var featureParameters = from ack in xdoc.Descendants("FeatureParameters")
                                    select ack;

            var featureParameter = from ack in featureParameters.Descendants("FeatureParameter")
                                   select ack;

            feature.parameters = new List<FeatureParameter>();
            int elementCount = featureParameter.Count();
            for (int i = 0; i < elementCount; i++)
            {
                FeatureParameter feaParam = new FeatureParameter(featureParameter.ElementAt(i).ToString());
                feature.parameters.Add(feaParam);
            }
            Console.WriteLine("feature.parameters Count==> " + feature.parameters.Count);
            return feature;
        }

    }
}
