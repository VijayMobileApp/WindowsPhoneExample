using Microsoft.Phone.Controls;
using NewExample.Framework;
using NewExample.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.ComponentModel;

namespace NewExample.Views
{
    public partial class SlideExample : PhoneApplicationPage
    {
        private double _dragDistanceToOpen = 75.0;
        private double _dragDistanceToClose = 305.0;
        private double _dragDistanceNegative = -75.0;

        private FrameworkElement _feContainer;

        public SlideExample()
        {
            InitializeComponent();
            // DataContext = App.ViewModel;

            _feContainer = this.Container as FrameworkElement;
        }
        private bool _isSettingsOpen = false;

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            if (_isSettingsOpen)
            {
                CloseSettings();
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                CloseSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message==> " + ex);
            }
        }



        private void CloseSettings()
        {
            var trans = _feContainer.GetHorizontalOffset().Transform;
            trans.Animate(trans.X, 0, TranslateTransform.XProperty, 300, 0, new CubicEase
            {
                EasingMode = EasingMode.EaseOut
            });

            _isSettingsOpen = false;
        }

        private void OpenSettings()
        {
            var trans = _feContainer.GetHorizontalOffset().Transform;
            trans.Animate(trans.X, 380, TranslateTransform.XProperty, 300, 0, new CubicEase
            {
                EasingMode = EasingMode.EaseOut
            });

            _isSettingsOpen = true;
        }

        private void GestureListener_OnDragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange > 0 && !_isSettingsOpen)
            {
                double offset = _feContainer.GetHorizontalOffset().Value + e.HorizontalChange;
                if (offset > _dragDistanceToOpen)
                    this.OpenSettings();
                else
                    _feContainer.SetHorizontalOffset(offset);
            }

            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange < 0 && _isSettingsOpen)
            {
                double offsetContainer = _feContainer.GetHorizontalOffset().Value + e.HorizontalChange;
                if (offsetContainer < _dragDistanceToClose)
                    this.CloseSettings();
                else
                    _feContainer.SetHorizontalOffset(offsetContainer);
            }
        }

        private void GestureListener_OnDragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange > 0 && !_isSettingsOpen)
            {
                if (e.HorizontalChange < _dragDistanceToOpen)
                    this.ResetLayoutRoot();
                else
                    this.OpenSettings();
            }

            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange < 0 && _isSettingsOpen)
            {
                if (e.HorizontalChange > _dragDistanceNegative)
                    this.ResetLayoutRoot();
                else
                    this.CloseSettings();
            }
        }

        private void SettingsStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            ResetLayoutRoot();
        }

        private void ResetLayoutRoot()
        {
            if (!_isSettingsOpen)
                _feContainer.SetHorizontalOffset(0.0);
            else
                _feContainer.SetHorizontalOffset(380.0);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (_isSettingsOpen)
            {
                CloseSettings();
            }
            else
            {
                OpenSettings();
            }
        }
    }
}