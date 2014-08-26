using System.Windows;
using Microsoft.Phone.Controls.Maps;
using NewExample.Model;
using System.Device.Location;

namespace NewExample
{
    public class MapViewDependencyProperty : DependencyObject
    {
        public LocationRect View
        {
            get
            {
                return (LocationRect)GetValue(ViewProperty);
            }
            set
            {
                SetValue(ViewProperty, value);
            }
        }

        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register("View", typeof(LocationRect), typeof(Map), new PropertyMetadata(null, new PropertyChangedCallback(onViewChanged)));


        private static void onViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MapPageModel pp = new MapPageModel();
            pp.location = new GeoCoordinate(double.Parse(Constants.latitude), double.Parse(Constants.longitude));
            pp.zoom = 4.0;
            var map = d as Map;
            if (map != null)
                map.SetView(pp.location, pp.zoom);
        }

        public static void SetView(UIElement element, LocationRect value)
        {

        }

        public static string GetView(UIElement element)
        {
            return null;
        }
    }
}
