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
using ReactiveUI;
using ReactiveUI.Xaml;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps.Platform;
using System.Collections.ObjectModel;
using NewExample.Model;
using NewExample.Views;
using System.ComponentModel;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ViewModel
{
    public class MapPageViewModel : ReactiveObject, INotifyPropertyChanged
    {
        public string _longitude;
        public string longitude
        {
            get { return _longitude; }
            set { this.RaiseAndSetIfChanged(x => x.longitude, value); }
        }

        public string _latitude;
        public string latitude
        {
            get { return _latitude; }
            set { this.RaiseAndSetIfChanged(x => x.latitude, value); }
        }

        public ReactiveAsyncCommand setButton { get; set; }

        public class MyLocation
        {
            public GeoCoordinate Coordinate { set; get; }
            public string Title { get; set; }
        }

        private ObservableCollection<MyLocation> locations = new ObservableCollection<MyLocation>();

        public ObservableCollection<MyLocation> Locations
        {
            get
            {
                return locations;
            }
        }

        public LocationRect LocationView
        {
            get
            {
                return LocationRect.CreateLocationRect(from l in locations select l.Coordinate);
            }

        }
        public MapPageViewModel()
        {
            setButton = new ReactiveAsyncCommand();
            setButton.Subscribe(x =>
            {
                if (!string.IsNullOrEmpty(latitude) && !string.IsNullOrEmpty(longitude))
                {
                    if (double.Parse(latitude) <= 90 && !(double.Parse(latitude) < 0) && double.Parse(longitude) <= 180 && !(double.Parse(longitude) < -181))
                    {
                        Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            Constants.longitude = longitude;
                            Constants.latitude = latitude;

                            locations.Add(new MyLocation()
                            {
                                Coordinate = new GeoCoordinate(double.Parse(latitude), double.Parse(longitude)),
                                Title = "Point 1"
                            });
                            RaisePropertyChanged("LocationView");
                        });
                    }
                    else
                        MessageBox.Show("Invalid GeoCoordinate");
                }

            });
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
