﻿using System.ComponentModel.DataAnnotations;

namespace StravaSegmentSniper.Data.Entities.Misc
{
    public class Bike
    {
        [Key]
        public string Id { get; set; }
        public bool Primary { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int ResourceState { get; set; }
        public bool Retired { get; set; }
        public int Distance { get; set; }
        public double ConvertedDistance { get; set; }
    }
}
