export type Segment = {
  id: string;
  name: string;
  distance: number;
};

export type SegmentEffort = {
  id: string;
  name: string;
  segment: Segment;
};
