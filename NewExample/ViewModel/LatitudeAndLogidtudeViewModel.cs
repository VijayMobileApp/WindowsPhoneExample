using System.Device.Location;
using System;
using System.Windows;
using ReactiveUI;
using NewExample.Model;
using NewExample.Const;

namespace NewExample.ViewModel
{
    public class LatitudeAndLogidtudeViewModel : ReactiveObject
    {
        public static double _latitude;
        public double latitude
        {
            get { return _latitude; }
            set { this.RaiseAndSetIfChanged(x => x.latitude, value); }
        }

        public static double _longitude;
        public double longitude
        {
            get { return _longitude; }
            set { this.RaiseAndSetIfChanged(x => x.longitude, value); }
        }

        public static double _defaultLatitude = 9.921332;
        public double defaultLatitude
        {
            get { return _defaultLatitude; }
            set { this.RaiseAndSetIfChanged(x => x.defaultLatitude, value); }
        }

        public static double _defaultLongitude = 78.116956;
        public double defaultLongitude
        {
            get { return _defaultLongitude; }
            set { this.RaiseAndSetIfChanged(x => x.defaultLongitude, value); }
        }


        public static string _distance;
        public string distance
        {
            get { return _distance; }
            set { this.RaiseAndSetIfChanged(x => x.distance, value); }
        }

        GeoCoordinateWatcher watcher;
        GeoCoordinateWatcher myLocationWatcher;
        public LatitudeAndLogidtudeViewModel()
        {
            AppConstant.getGeoLocation.drive();
            latitude = double.Parse(AppConstant.latitude);
            longitude = double.Parse(AppConstant.longitude);
            //To calculate the Distance between two coordinates.
            var sCoord = new GeoCoordinate(latitude, longitude);
            var eCoord = new GeoCoordinate(defaultLatitude, defaultLongitude);
            double dist = sCoord.GetDistanceTo(eCoord);
            double km = dist / 1000;
            distance = sCoord.GetDistanceTo(eCoord).ToString("0.00");
            Console.WriteLine(km.ToString("0.00"));
            ////First Method to get the location
            ////getLatAndLong();
            ////Second Method to get the location
            ////StartLocationService(GeoPositionAccuracy.High);
        }

        void getLatAndLong()
        {
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
                watcher.MovementThreshold = 20;
                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
                watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            }
            watcher.Start();
        }

        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    MessageBox.Show("Location Service is not enabled on the device");
                    break;

                case GeoPositionStatus.NoData:
                    MessageBox.Show(" The Location Service is working, but it cannot get location data.");
                    break;
            }
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (e.Position.Location.IsUnknown)
            {
                // this.notification.Text = "Please wait while your prosition is determined....";
                return;
            }

            //latitude = e.Position.Location.Latitude.ToString("0.000000");
            //longitude = e.Position.Location.Longitude.ToString("0.000000");
        }


        //private void StartLocationService(GeoPositionAccuracy accuracy)
        //{
        //    myLocationWatcher = new GeoCoordinateWatcher(accuracy);
        //    myLocationWatcher.MovementThreshold = 20;

        //    myLocationWatcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
        //    myLocationWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);

        //    myLocationWatcher.Start();
        //}

        //void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        //{
        //    Deployment.Current.Dispatcher.BeginInvoke(() => MyStatusChanged(e));
        //}

        //void MyStatusChanged(GeoPositionStatusChangedEventArgs e)
        //{
        //    switch (e.Status)
        //    {
        //        case GeoPositionStatus.Disabled:
        //            MessageBox.Show("location is unsupported on this device");
        //            break;
        //    }
        //}

        //void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        //{
        //    Deployment.Current.Dispatcher.BeginInvoke(() => MyPositionChanged(e));
        //}

        //void MyPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        //{
        //    AppGlobalConstants.latitude = e.Position.Location.Latitude.ToString("0.000000");
        //    AppGlobalConstants.longitude = e.Position.Location.Longitude.ToString("0.000000");
        //    Console.WriteLine("AppGlobalConstants.latitude 0==>" + AppGlobalConstants.latitude);
        //    Console.WriteLine("AppGlobalConstants.longitude 0==>" + AppGlobalConstants.longitude);

        //    //MessageBox.Show("Latitude" + e.Position.Location.Latitude.ToString("0.000"));
        //    //MessageBox.Show("Longitude" + e.Position.Location.Longitude.ToString("0.000"));
        //    //Update the TextBlocks to show the current location
        //    //LatitudeTextBlock.Text = e.Position.Location.Latitude.ToString("0.000");
        //    //LongitudeTextBlock.Text = e.Position.Location.Longitude.ToString("0.000");
        //}
    }
}
