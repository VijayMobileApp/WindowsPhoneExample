using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class Ratings : ReactiveObject
    {
        public static int _totalRatingCount;
        public int totalRatingCount
        {
            get { return _totalRatingCount; }
            set { this.RaiseAndSetIfChanged(x => x.totalRatingCount, value); }
        }

        public static int _totalRatingCountBeno;
        public int totalRatingCountBeno
        {
            get { return _totalRatingCountBeno; }
            set { this.RaiseAndSetIfChanged(x => x.totalRatingCountBeno, value); }
        }

        public static int _totalRatingCountFacebook;
        public int totalRatingCountFacebook
        {
            get { return _totalRatingCountFacebook; }
            set { this.RaiseAndSetIfChanged(x => x.totalRatingCountFacebook, value); }
        }

        public static int _totalRatingCountTwitter;
        public int totalRatingCountTwitter
        {
            get { return _totalRatingCountTwitter; }
            set { this.RaiseAndSetIfChanged(x => x.totalRatingCountTwitter, value); }
        }


        public static string _ratingValue;
        public string ratingValue
        {
            get { return _ratingValue; }
            set { this.RaiseAndSetIfChanged(x => x.ratingValue, value); }
        }

        //public static Dictionary<string, Rating> _ratingList;
        //public Dictionary<string, Rating> ratingList
        //{
        //    get { return _ratingList; }
        //    set { this.RaiseAndSetIfChanged(x => x.ratingList, value); }
        //}

        //public static List<Rating> _ratings;
        //public List<Rating> ratings
        //{
        //    get { return _ratings; }
        //    set { this.RaiseAndSetIfChanged(x => x.ratings, value); }
        //}

        //public List<Rating> getRatings()
        //{
        //    if (ratings == null)
        //    {
        //        ratings = new List<Rating>();

        //        for (int i = 5; i > 0; i--)
        //        {
        //            if (ratingList.ContainsKey(i.ToString()))
        //            {
        //                ratings.Add(ratingList[(i.ToString())]);
        //            }
        //            else
        //            {
        //                ratings.Add(new Rating(i, 0));
        //            }
        //        }
        //    }
        //    return ratings;
        //}

        public static Ratings extracts(string ratingsInformation)
        {

            String[] searchTags = { "TotalRatingCount", "TotalRatingCountBeno", "TotalRatingCountFacebook", "TotalRatingCountTwitter", "RatingValue" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(ratingsInformation);
            Ratings rating = new Ratings();
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

            rating.totalRatingCount = int.Parse(result.ElementAt(0));
            rating.totalRatingCountBeno = int.Parse(result.ElementAt(1));
            rating.totalRatingCountFacebook = int.Parse(result.ElementAt(2));
            rating.totalRatingCountTwitter = int.Parse(result.ElementAt(3));
            rating.ratingValue = result.ElementAt(4);           
            return rating;
        }
    }
}
