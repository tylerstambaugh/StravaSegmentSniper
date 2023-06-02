using StravaSegmentSniper.Services.Internal.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.Internal.Models.Activity
{
    public class ActivityListModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public int ElapsedTime { get; set; }
        public double? MaxSpeed { get; set; }
        public string? GearId { get; set; }
        public PolylineMapModel? StravaMap { get; set; }
    }
}
