import { SegmentEffort } from "../SegmentEfforts";
import { StravaMap } from "./ActivityListItem";

type DetailedActivity = {
  name: string;
  distance: number;
  id: string;
  type: string;
  startDate: Date;
  achievementCount: number;
  startLatLng: [number, number];
  endLatLng: [number, number];
  maxSpeed: number;
  stravaMap: StravaMap;
  segmentEfforts: SegmentEffort[];
};