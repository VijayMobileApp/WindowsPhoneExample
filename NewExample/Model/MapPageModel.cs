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
using Microsoft.Phone.Controls.Maps.Platform;
using System.Device.Location;

namespace NewExample.Model
{
    public class MapPageModel
    {
        public  GeoCoordinate location { get; set; }
        public string text { get; set; }
        public double zoom { get; set; }
    }
}
