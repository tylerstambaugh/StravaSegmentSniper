import { SegmentEffort } from "./SegmentEfforts";

type DetailedActivity = {
  name: string;
  distance: number;
  id: string;
  startDate: Date;
  achievementCount: number;
  startLatLng: [number, number];
  endLatLng: [number, number];
  maxSpeed: number;
  segmentEfforts: SegmentEffort[];
};

type StravaMap = {
  id: string;
  polyline: string;
  summaryPolyline: string;
};
