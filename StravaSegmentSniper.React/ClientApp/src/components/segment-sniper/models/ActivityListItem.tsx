export interface ActivityListItem {
  name: string;
  distance: number;
  id: string;
  type: string;
  startDate: Date;
  achievementCount?: number;
  maxSpeed?: number;
  geardId?: string;
  stravaMap?: StravaMap;
}

export interface StravaMap {
  id: string;
  polyline?: string;
  summaryPolyline?: string;
}
