
using System.Device.Location;
using System;
using System.Windows;

namespace NewExample.Const
{
    public class GetGeoLocation
    {
        GeoCoordinateWatcher watcher;
        public static string longitude = "0.0";
        public static string latitude = "0.0";

        public GetGeoLocation()
        {
            drive();
        }

        public void drive()
        {
            getLatAndLong();
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
            AppConstant.latitude = e.Position.Location.Latitude.ToString("0.000000");
            AppConstant.longitude = e.Position.Location.Longitude.ToString("0.000000");
        }
    }
}
