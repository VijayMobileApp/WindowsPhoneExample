
using Microsoft.Phone.Controls;
using NewExample.ViewModel;
using System;
using System.Device.Location;
using System.Windows;

namespace NewExample.Views
{
    public partial class LatitudeAndLogidtude : PhoneApplicationPage
    {
        GeoCoordinateWatcher myLocationWatcher;
        public LatitudeAndLogidtude()
        {
            InitializeComponent();
            this.DataContext = new LatitudeAndLogidtudeViewModel();
            //StartLocationService(GeoPositionAccuracy.High);
        }

        /// <summary>
        /// Click event handler for the high accuracy button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetLocation(object sender, EventArgs e)
        {
            // Start data acquisition from the Location Service, high accuracy
            //accuracy can be one default and another high
            StartLocationService(GeoPositionAccuracy.High);
        }

        /// <summary>
        /// Helper method to start up the location data acquisition
        /// </summary>
        /// <param name="accuracy">The accuracy level </param>
        private void StartLocationService(GeoPositionAccuracy accuracy)
        {
            // Reinitialize the GeoCoordinateWatcher
            myLocationWatcher = new GeoCoordinateWatcher(accuracy);
            myLocationWatcher.MovementThreshold = 20;

            // Add event handlers for StatusChanged and PositionChanged events
            myLocationWatcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
            myLocationWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);

            // Start data acquisition
            myLocationWatcher.Start();
        }

        /// <summary>
        /// Handler for the StatusChanged event. This invokes MyStatusChanged on the UI thread and
        /// passes the GeoPositionStatusChangedEventArgs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            //the dispatcher dispatches to the specified method when a status change occurs
            Deployment.Current.Dispatcher.BeginInvoke(() => MyStatusChanged(e));

        }

        /// <summary>
        /// Custom method called from the StatusChanged event handler
        /// </summary>
        /// <param name="e"></param>
        void MyStatusChanged(GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // The location service is disabled or unsupported.
                    // Alert the user
                    MessageBox.Show("location is unsupported on this device");
                    break;
            }
        }

        /// <summary>
        /// Handler for the PositionChanged event. This invokes MyStatusChanged on the UI thread and
        /// passes the GeoPositionStatusChangedEventArgs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            //Dispatcher invokes the event for position change.
            Deployment.Current.Dispatcher.BeginInvoke(() => MyPositionChanged(e));
        }

        /// <summary>
        /// Custom method called from the PositionChanged event handler
        /// </summary>
        /// <param name="e"></param>
        void MyPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            MessageBox.Show("Latitude" + e.Position.Location.Latitude.ToString("0.000"));
            MessageBox.Show("Longitude" + e.Position.Location.Longitude.ToString("0.000"));
            // Update the TextBlocks to show the current location
            //LatitudeTextBlock.Text = e.Position.Location.Latitude.ToString("0.000");
            //LongitudeTextBlock.Text = e.Position.Location.Longitude.ToString("0.000");
        }

    }
}