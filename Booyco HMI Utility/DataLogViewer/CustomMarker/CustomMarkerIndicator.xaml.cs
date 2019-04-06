﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using GMap.NET.WindowsPresentation;

using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using System.ComponentModel;
using Booyco_HMI_Utility;
using Booyco_HMI_Utility.CustomMarker;

namespace Demo.WindowsPresentation.CustomMarkers
{
   /// <summary>
   /// Interaction logic for CustomMarkerDemo.xaml
   /// </summary>
   public partial class CustomMarkerIndicator
   {
      Popup Popup;
      Label Label;
      GMapMarker Marker;
      MainWindow MainWindow;
        GMapControl mapControl;


      public CustomMarkerIndicator(GMapControl _mapControl, MarkerEntry marker)
      {
        this.InitializeComponent();
        this.mapControl = _mapControl;
        this.Marker = marker.MapMarker;

        Popup = new Popup();
        Label = new Label();

            RotateTransform IndicatorTransfrom = new RotateTransform(marker.Heading);
            PathIndicator.LayoutTransform = IndicatorTransfrom;

            if (marker.Zone == 1)
            {
                PathIndicator.Fill = Brushes.Blue;
               
            }
            else if (marker.Zone == 2)
            {
                PathIndicator.Fill = Brushes.Yellow;
            }
            else if (marker.Zone == 3)
            {
                PathIndicator.Fill = Brushes.Red;
            }
            else
            {
                PathIndicator.Fill = Brushes.Transparent;
            }

            //CustomMarkerAngle = (Double) (Heading + 180);

        this.SizeChanged += new SizeChangedEventHandler(CustomMarkerIndicator_SizeChanged);
            //this.MouseEnter += new MouseEventHandler(CustomMarkerIndicator_MouseEnter);
            //this.MouseLeave += new MouseEventHandler(CustomMarkerIndicator_MouseLeave);

            //Popup.Placement = PlacementMode.Mouse;
            //{
            //    Label.Background = Brushes.Gray;
            //    Label.Foreground = Brushes.White;
            //    Label.BorderBrush = Brushes.Black;
            //    Label.BorderThickness = new Thickness(2);
            //    Label.Padding = new Thickness(5);
            //    Label.FontSize = 12;
            //    Label.Content = marker.title;
            //}

            Label_PopupInfo.Content = marker.title;
            Ellipse_PresenceZone.Width = marker.PresenceZoneSize / marker.Scale;
            Ellipse_PresenceZone.Height = marker.PresenceZoneSize / marker.Scale;

            Ellipse_WarningZone.Width = marker.WarningZoneSize / marker.Scale;
            Ellipse_WarningZone.Height = marker.WarningZoneSize / marker.Scale;
            Ellipse_WarningZoneBackground.Width = marker.WarningZoneSize / marker.Scale;
            Ellipse_WarningZoneBackground.Height = marker.WarningZoneSize / marker.Scale;

            Ellipse_CriticalZone.Width = marker.CriticalZoneSize / marker.Scale;
            Ellipse_CriticalZone.Height = marker.CriticalZoneSize / marker.Scale;
            Ellipse_CriticalZoneBackground.Width = marker.CriticalZoneSize / marker.Scale;
            Ellipse_CriticalZoneBackground.Height = marker.CriticalZoneSize / marker.Scale;

            Popup.Child = Label;
      }
        private Double _CustomMarkerAngle;
        public Double CustomMarkerAngle
        {
            get { return _CustomMarkerAngle; }
            set
            {
                _CustomMarkerAngle = value;
                OnPropertyChanged("CustomMarkerAngle");
            }
        }

      void CustomMarkerIndicator_SizeChanged(object sender, SizeChangedEventArgs e)
      {
         Marker.Offset = new Point(-e.NewSize.Width/2, -e.NewSize.Height/2);
      }

      void CustomMarkerIndicator_MouseMove(object sender, MouseEventArgs e)
      {
         if(e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
         {
            Point p = e.GetPosition(mapControl);
            Marker.Position = mapControl.FromLocalToLatLng((int) p.X, (int) p.Y);
         }
      }

      void CustomMarkerIndicator_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
      {
            //if(!IsMouseCaptured)
            //{
            //   Mouse.Capture(this);
            //}
            if (!Label_PopupInfo.IsVisible)
            {
                Label_PopupInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Label_PopupInfo.Visibility = Visibility.Collapsed;
               
            }

        }

      void CustomMarkerIndicator_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
      {
            //if(IsMouseCaptured)
            //{
            //   Mouse.Capture(null);
            //}
          //  Popup.IsOpen = false;

        }

        void CustomMarkerIndicator_MouseLeave(object sender, MouseEventArgs e)
      {
            PathIndicator.Opacity = 1;
        // Marker.ZIndex -= 10000;
      
            Ellipse_CriticalZone.Visibility = Visibility.Collapsed;
            Ellipse_WarningZoneBackground.Visibility = Visibility.Collapsed;
            Ellipse_WarningZone.Visibility = Visibility.Collapsed;
            Ellipse_CriticalZoneBackground.Visibility = Visibility.Collapsed;
            Ellipse_PresenceZone.Visibility = Visibility.Collapsed;
           
        }

      void CustomMarkerIndicator_MouseEnter(object sender, MouseEventArgs e)
      {
            PathIndicator.Opacity = 0.5;
            //Marker.ZIndex += 10000;
        
            Ellipse_CriticalZone.Visibility = Visibility.Visible;
            Ellipse_WarningZoneBackground.Visibility = Visibility.Visible;
            Ellipse_WarningZone.Visibility = Visibility.Visible;
            Ellipse_CriticalZoneBackground.Visibility = Visibility.Visible;
            Ellipse_PresenceZone.Visibility = Visibility.Visible;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}