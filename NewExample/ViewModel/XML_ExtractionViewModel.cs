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
using System.Xml.Linq;
using System.Collections.ObjectModel;
using NewExample.Model;
using ReactiveUI;
using ReactiveUI.Xaml;
using System.Collections.Generic;

namespace NewExample.ViewModel
{
    public class XML_ExtractionViewModel : ReactiveObject
    {
        public List<XML_ExtractionModel> _RateDetails;
        public List<XML_ExtractionModel> RateDetails
        {
            get { return _RateDetails; }
            set { this.RaiseAndSetIfChanged(x => x.RateDetails, value); }
        }

        public  List<XML_ExtractionModel> _barRatingDetails;
        public List<XML_ExtractionModel> barRatingDetails
        {
            get { return _barRatingDetails; }
            set { this.RaiseAndSetIfChanged(x => x.barRatingDetails, value); }
        }

        public static int _rectWidth5;
        public int rectWidth5
        {
            get { return _rectWidth5; }
            set { this.RaiseAndSetIfChanged(x => x.rectWidth5, value); }
        }

        public static int _rectWidth4;
        public int rectWidth4
        {
            get { return _rectWidth4; }
            set { this.RaiseAndSetIfChanged(x => x.rectWidth4, value); }
        }

        public static int _rectWidth3;
        public int rectWidth3
        {
            get { return _rectWidth3; }
            set { this.RaiseAndSetIfChanged(x => x.rectWidth3, value); }
        }

        public static int _rectWidth2;
        public int rectWidth2
        {
            get { return _rectWidth2; }
            set { this.RaiseAndSetIfChanged(x => x.rectWidth2, value); }
        }

        public static int _rectWidth1;
        public int rectWidth1
        {
            get { return _rectWidth1; }
            set { this.RaiseAndSetIfChanged(x => x.rectWidth1, value); }
        }
   

        XDocument myData = XDocument.Load("RatingXML.xml");

        public XML_ExtractionViewModel()
        {
            var getRateDetails = new ReactiveAsyncCommand();

            getRateDetails.Subscribe(x =>
            {
                RateDetails = new List<XML_ExtractionModel>();
                RateDetails = XML_ExtractionModel.extract(myData.ToString());
               
                //rectWidth1 = RateDetails[0].rectWidth1;
                //Console.WriteLine("1==>" + rectWidth1);

                //rectWidth2 = RateDetails[0].rectWidth2;
                //Console.WriteLine("2==>" + rectWidth2);

                //rectWidth3 = RateDetails[0].rectWidth3;
                //Console.WriteLine("3==>" + rectWidth3);

                //rectWidth4 = RateDetails[0].rectWidth4;
                //Console.WriteLine("4==>" + rectWidth4);

                //rectWidth5 = RateDetails[0].rectWidth5;
                //Console.WriteLine("5==>" + rectWidth5);
              
            });
            getRateDetails.Execute(true);

            
        }
    }
}
