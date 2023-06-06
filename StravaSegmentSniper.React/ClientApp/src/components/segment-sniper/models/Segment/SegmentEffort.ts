import { Segment } from "./Segment";

export interface SegmentEffortListItem {
  id: number;
  activityId: number;
  elapsed_time: number;
  distance: number;
  kom_rank: number | null;
}

export interface SegmentEffort {
  id: number;
  resource_state: number;
  name: string;
  activity: {
    id: number;
    resource_state: number;
  };
  athlete: {
    id: number;
    resource_state: number;
  };
  elapsed_time: number;
  moving_time: number;
  start_date: string;
  start_date_local: string;
  distance: number;
  start_index: number;
  end_index: number;
  device_watts: boolean;
  average_watts: number;
  average_heartrate: number;
  max_heartrate: number;
  segment: {
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
    elevation_profile: string | null;
    climb_category: number;
    city: string;
    state: string;
    country: string;
    private: boolean;
    hazardous: boolean;
    starred: boolean;
  };
  pr_rank: number | null;
  achievements: {
    type_id: number;
    type: string;
    rank: number;
  }[];
  kom_rank: number | null;
  hidden: boolean;
}
