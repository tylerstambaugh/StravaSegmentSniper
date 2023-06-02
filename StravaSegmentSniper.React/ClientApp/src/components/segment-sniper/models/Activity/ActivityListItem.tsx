export interface ActivityListItem {
  name: string;
  id: string;
  type: string;
  startDate: Date;
  distance: number;
  elapsedTime: number;
  achievementCount?: number;
  maxSpeed?: number;
  gearId?: string;
  stravaMap?: StravaMap;
}

export interface StravaMap {
  id: string;
  polyline?: string;
  summaryPolyline?: string;
}
