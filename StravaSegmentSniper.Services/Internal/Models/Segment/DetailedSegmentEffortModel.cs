﻿using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Athlete;

namespace StravaSegmentSniper.Services.Internal.Models.Segment
{
    public class DetailedSegmentEffortModel
    {
        public long SegmentEffortId { get; set; }
        public int ResourceState { get; set; }
        public string Name { get; set; }
        public ActivityModel Activity { get; set; }
        public MetaAthleteModel Athlete { get; set; }
        public int ElapsedTime { get; set; }
        public int MovingTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal { get; set; }
        public double Distance { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public bool DeviceWatts { get; set; }
        public double AverageWatts { get; set; }
        public double AverageHeartrate { get; set; }
        public double MaxHeartrate { get; set; }
        public SummarySegmentModel Segment { get; set; }
        public int? PrRank { get; set; }
        public List<AchievementModel> Achievements { get; set; }
        public bool Hidden { get; set; }
    }

}
