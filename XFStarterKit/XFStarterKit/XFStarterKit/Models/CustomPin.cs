﻿using Xamarin.Forms.Maps;

namespace XFStarterKit.Core.Models
{
    public class CustomPin
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string PinIcon { get; set; }

        public string Address { get; set; }

        public Position Position { get; set; }

        public SuggestionType Type { get; set; }
    }
}