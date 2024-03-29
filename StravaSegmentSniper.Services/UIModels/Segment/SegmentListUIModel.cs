﻿using StravaSegmentSniper.Services.Internal.Models.Misc;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.UIModels.Segment
{
    public class SegmentEffortUIListModel
    {
        public long SegmentEffortId { get; set; }
        public long SegmentId { get; set; }
        public string ActivityId { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string ActivityType { get; set; }
        public double Distance { get; set; }
        public DateTime CreatedAt { get; set; }
        public PolylineMapModel Map { get; set; }
        public int EffortCount { get; set; }
        public int AthleteCount { get; set; }
        public int StarCount { get; set; }
        public bool Starred { get; set; }
        public AthleteSegmentStatsModel AthleteSegmentStats { get; set; }
        public XomsModel Xoms { get; set; }
        public int Rank { get; set; }
    }

 
}