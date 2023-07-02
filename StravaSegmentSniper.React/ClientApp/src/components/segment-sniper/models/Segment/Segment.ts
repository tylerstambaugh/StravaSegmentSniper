export interface SegmentListItem {
  id: string;
  name: string;
  time: number;
  distance: number;
  athleteStats?: athleteSegmentStats;
  koms?: xomsModel;
  rank?: number;
}

export interface SnipedSegmentListItem {
  id: string;
  name: string;
  komTime: string;
  distance: number;
  secondsFromLeader?: number;
  percentageFromLeader?: number;
  athleteStats?: athleteSegmentStats;
  koms?: xomsModel;
  useQom?: boolean;
}

export interface SegmentDetails {
  id: number;
  resource_state: number;
  name: string;
  activity_type: string;
  distance: number;
  average_grade: number;
  maximum_grade: number;
  elevation_high: number;
  elevation_low: number;
  start_latlng: [number, number];
  end_latlng: [number, number];
  elevation_profile: string;
  climb_category: number;
  city: string;
  state: string;
  country: string;
  private: boolean;
  hazardous: boolean;
  starred: boolean;
  created_at: string;
  updated_at: string;
  total_elevation_gain: number;
  map: {
    id: string;
    polyline: string;
    resource_state: number;
  };
  effort_count: number;
  athlete_count: number;
  star_count: number;
  athlete_segment_stats: {
    pr_elapsed_time: number;
    pr_date: string;
    pr_activity_id: number;
    effort_count: number;
  };
  xoms: {
    kom: string;
    qom: string;
    overall: string;
    destination: {
      href: string;
      type: string;
      name: string;
    };
  };
  local_legend: {
    athlete_id: number;
    title: string;
    profile: string;
    effort_description: string;
    effort_count: string;
    effort_counts: {
      overall: string;
      female: string;
    };
    destination: string;
  };
}

export interface xomsModel {
  komTime: string;
  qomTime: string;
}

export interface athleteSegmentStats {
  pr_elapsed_time: number;
  pr_date: string;
  pr_activity_id: number;
  effort_count: number;
}
