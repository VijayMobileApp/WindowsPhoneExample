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
using System.Collections.Generic;


namespace NewExample.Model
{
    public class XML_ExtractionModel
    {
        public string ratingInterval { get; set; }
        public string rating { get; set; }

        public double rectWidth5 { get; set; }
        public string barRating5 { get; set; }

        public double rectWidth4 { get; set; }
        public string barRating4 { get; set; }

        public double rectWidth3 { get; set; }
        public string barRating3 { get; set; }


        public double rectWidth2 { get; set; }
        public string barRating2 { get; set; }


        public double rectWidth1 { get; set; }
        public string barRating1 { get; set; }


        public static List<XML_ExtractionModel> extract(string result)
        {
            List<XML_ExtractionModel> content1 = new List<XML_ExtractionModel>();
            XML_ExtractionModel lgp = new XML_ExtractionModel();
            XML_ExtractionModel lgp1 = new XML_ExtractionModel();
            List<XML_ExtractionModel> content = new List<XML_ExtractionModel>();
            XDocument xdoc = XDocument.Parse(result);
            int rateInter, totCount = 0, deftWidth = 210;
            double avgCount, bar1, bar2, bar3, bar4, bar5, rateCount;

            var res = from query in xdoc.Descendants("Rating")
                      select query;

            for (int i = 0; i < res.Count(); i++)
            {
                lgp.ratingInterval = res.ElementAt(i).Element("RatingInterval").Value;
                lgp.rating = res.ElementAt(i).Element("RatingCount").Value;
                totCount = totCount + int.Parse(lgp.rating);
                content.Add(lgp);
                lgp = new XML_ExtractionModel();
            }

            avgCount = 2;

            for (int i = 0; i < content.Count(); i++)
            {
                rateInter = int.Parse(content.ElementAt(i).ratingInterval);
                rateCount = double.Parse(content.ElementAt(i).rating);

                if (i == 0)
                {
                    bar1 = (rateCount * 100) / avgCount;
                    lgp1.rectWidth1 = ((bar1 / 100) * deftWidth);
                    lgp1.barRating1 = (i + 1).ToString();

                }
                if (i == 1)
                {
                    bar2 = (rateCount * 100) / avgCount;
                    lgp1.rectWidth2 = ((bar2 / 100) * deftWidth);
                    lgp1.barRating2 = (i + 1).ToString();

                }
                if (i == 2)
                {
                    bar3 = (rateCount * 100) / avgCount;
                    lgp1.rectWidth3 = ((bar3 / 100) * deftWidth);
                    lgp1.barRating3 = (i + 1).ToString();
                }
                if (i == 3)
                {
                    bar4 = (rateCount * 100) / avgCount;
                    lgp1.rectWidth4 = ((bar4 / 100) * deftWidth);
                    lgp1.barRating4 = (i + 1).ToString();
                }
                if (i == 4)
                {
                    bar5 = (rateCount * 100) / avgCount;
                    lgp1.rectWidth5 = ((bar5 / 100) * deftWidth);
                    lgp1.barRating5 = (i + 1).ToString();
                }
            }
            content1.Add(lgp1);

            return content1;
        }
    }
}


/*


                    //totCount = OrganizationInfoBasic._ratings.totalRatingCountBeno;
                    //for (int i = 0; i < 5; i++)
                    //{
                    //     Rating.extracts(res.ElementAt(i).ToString());
                    //     rateInter = Rating._ratingInterval;
                    //     rateCount = (double)Rating._ratingCount;

                    //    if (i == 0)
                    //    {
                    //        bar1 = (rateCount * 100) / totCount;
                    //        orgStr.rectWidth1 = ((bar1 / 100) * deftWidth);
                    //        orgStr.barRating1 = (i + 1).ToString();

                    //    }
                    //    if (i == 1)
                    //    {
                    //        bar2 = (rateCount * 100) / totCount;
                    //        orgStr.rectWidth2 = ((bar2 / 100) * deftWidth);
                    //        orgStr.barRating2 = (i + 1).ToString();

                    //    }
                    //    if (i == 2)
                    //    {
                    //        bar3 = (rateCount * 100) / totCount;
                    //        orgStr.rectWidth3 = ((bar3 / 100) * deftWidth);
                    //        orgStr.barRating3 = (i + 1).ToString();
                    //    }
                    //    if (i == 3)
                    //    {
                    //        bar4 = (rateCount * 100) / totCount;
                    //        orgStr.rectWidth4 = ((bar4 / 100) * deftWidth);
                    //        orgStr.barRating4 = (i + 1).ToString();
                    //    }
                    //    if (i == 4)
                    //    {
                    //        bar5 = (rateCount * 100) / totCount;
                    //        orgStr.rectWidth5 = ((bar5 / 100) * deftWidth);
                    //        orgStr.barRating5 = (i + 1).ToString();
                    //    }
                    //}
*/