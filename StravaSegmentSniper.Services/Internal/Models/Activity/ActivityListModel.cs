using StravaSegmentSniper.Services.Internal.Models.Misc;
using StravaSegmentSniper.Services.UIModels.Segment;
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
        public int ElapsedTimeSeconds { get; set; }
        public string ElapsedTime { get; set; }
        public double? MaxSpeed { get; set; }
        public string? GearId { get; set; }
        public PolylineMapModel? StravaMap { get; set; }
        public List<SegmentEffortUIListModel> Segments { get; set; }
    }
}
