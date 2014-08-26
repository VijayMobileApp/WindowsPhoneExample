using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using NewExample.ViewModel;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;

namespace NewExample.Views
{
    public partial class MapPage : PhoneApplicationPage
    {
        public double zoom = 6.0;
        public MapPage()
        {
            InitializeComponent();
            //map1.CredentialsProvider = new ApplicationIdCredentialsProvider("Asa2x7ZzhYIHauji6TzIkcf3TIDznTgBaPKQehsyE4taOz19Mx4fP4lyihqbTj7D");
            map1.Mode = new RoadMode();//This is for Road View Map
            //map1.Mode = new AerialMode(true); // This is for Satilite View Map
            MapPageUIContainer.DataContext = new MapPageViewModel();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Pushpin p = new Pushpin();
            //p.Background = new SolidColorBrush(Colors.Yellow);
            //p.Foreground = new SolidColorBrush(Colors.Black);
            //p.Location = new GeoCoordinate(double.Parse(longitude.Text), double.Parse(latitude.Text));//Longitude and Latitude
            //p.Content = "I'm here";//To show the place where it is located
            //map1.Children.Add(p);
            //map1.SetView(new GeoCoordinate(double.Parse(longitude.Text), double.Parse(latitude.Text), 200), 9);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            double dbZoom;
            dbZoom = map1.ZoomLevel;
            map1.ZoomLevel = ++dbZoom;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            double dbZoom;
            dbZoom = map1.ZoomLevel;
            map1.ZoomLevel = --dbZoom;
        }
    }
}