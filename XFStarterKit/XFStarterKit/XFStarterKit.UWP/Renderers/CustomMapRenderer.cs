﻿using XFStarterKit.Core.Controls;
using XFStarterKit.Core.Helpers;
using XFStarterKit.Core.Models;
using XFStarterKit.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace XFStarterKit.UWP.Renderers
{
    public class CustomMapRenderer : MapRenderer
    {
        readonly RandomAccessStreamReference eventResource = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pushpin_01.png"));
        readonly RandomAccessStreamReference restaurantResource = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pushpin_02.png"));

        CustomMap customMap;
        List<CustomPin> customPins;
        List<CustomMapIcon> tempMapIcons;

        public CustomMapRenderer()
        {
            customPins = new List<CustomPin>();
            tempMapIcons = new List<CustomMapIcon>();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var windowsMapView = (MapControl)Control;
            customMap = (CustomMap)sender;

            if (e.PropertyName.Equals("CustomPins"))
            {
                customPins = customMap.CustomPins.ToList();
                ClearPushPins(windowsMapView);

                AddPushPins(windowsMapView, customMap.CustomPins);
                PositionMap();
            }
        }

        void ClearPushPins(MapControl mapControl) => mapControl.MapElements.Clear();

        void AddPushPins(MapControl mapControl, IEnumerable<CustomPin> pins)
        {
            if (tempMapIcons != null)
            {
                tempMapIcons.Clear();
            }

            foreach (var pin in pins)
            {
                var snPosition = new BasicGeoposition { Latitude = pin.Position.Latitude, Longitude = pin.Position.Longitude };
                var snPoint = new Geopoint(snPosition);

                var mapIcon = new CustomMapIcon
                {
                    Label = pin.Label,
                    MapIcon = new MapIcon
                    {
                        MapTabIndex = pin.Id,
                        CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible,
                        Location = snPoint,
                        NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0),
                        ZIndex = 0
                    }
                };

                switch (pin.Type)
                {
                    default:
                        mapIcon.MapIcon.Image = eventResource;
                        break;
                }

                mapControl.MapElements.Add(mapIcon.MapIcon);
                tempMapIcons.Add(mapIcon);
            }
        }

        void PositionMap()
        {
            var myMap = Element as CustomMap;
            var formsPins = myMap.CustomPins;

            if (formsPins == null || formsPins.Count() == 0)
            {
                return;
            }

            var centerPosition = new Position(formsPins.Average(x => x.Position.Latitude), formsPins.Average(x => x.Position.Longitude));

            var minLongitude = formsPins.Min(x => x.Position.Longitude);
            var minLatitude = formsPins.Min(x => x.Position.Latitude);

            var maxLongitude = formsPins.Max(x => x.Position.Longitude);
            var maxLatitude = formsPins.Max(x => x.Position.Latitude);

            var distance = MapHelper.CalculateDistance(minLatitude, minLongitude,
                maxLatitude, maxLongitude, 'M') / 2;

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMiles(distance)));
        }
    }

    public class CustomMapIcon
    {
        public string Label { get; set; }
        public MapIcon MapIcon { get; set; }
    }
}