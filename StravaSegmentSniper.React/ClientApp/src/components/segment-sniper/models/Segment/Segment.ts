export interface Segment {}

export interface SegmentListItem {
  id: string;
  name: string;
  time: number;
  distance: number;
}

// "segment_efforts": [
//     {
//         "id": 3094778815724456028,
//         "resource_state": 2,
//         "name": "Goose Creek Road",
//         "activity": {
//             "id": 9102798217,
//             "resource_state": 1
//         },
//         "athlete": {
//             "id": 381648,
//             "resource_state": 1
//         },
//         "elapsed_time": 640,
//         "moving_time": 638,
//         "start_date": "2023-05-19T18:03:49Z",
//         "start_date_local": "2023-05-19T14:03:49Z",
//         "distance": 2917.3,
//         "start_index": 583,
//         "end_index": 849,
//         "device_watts": false,
//         "average_watts": 186.6,
//         "average_heartrate": 127.4,
//         "max_heartrate": 150.0,
//         "segment": {
//             "id": 5289440,
//             "resource_state": 2,
//             "name": "Goose Creek Road",
//             "activity_type": "Ride",
//             "distance": 2917.3,
//             "average_grade": 2.7,
//             "maximum_grade": 16.3,
//             "elevation_high": 279.0,
//             "elevation_low": 197.8,
//             "start_latlng": [
//                 39.348323,
//                 -86.457422
//             ],
//             "end_latlng": [
//                 39.343793,
//                 -86.427522
//             ],
//             "elevation_profile": null,
//             "climb_category": 0,
//             "city": "Martinsville",
//             "state": "IN",
//             "country": "United States",
//             "private": false,
//             "hazardous": false,
//             "starred": false
//         },
//         "pr_rank": 3,
//         "achievements": [
//             {
//                 "type_id": 3,
//                 "type": "pr",
//                 "rank": 3
//             }
//         ],
//         "kom_rank": null,
//         "hidden": true
//     },
//     {
//         "id": 3094778815721800796,
//         "resource_state": 2,
//         "name": "Goose Creek Climb",
//         "activity": {
//             "id": 9102798217,
//             "resource_state": 1
//         },
//         "athlete": {
//             "id": 381648,
//             "resource_state": 1
//         },
//         "elapsed_time": 618,
//         "moving_time": 618,
//         "start_date": "2023-05-19T18:05:35Z",
//         "start_date_local": "2023-05-19T14:05:35Z",
//         "distance": 3084.0,
//         "start_index": 626,
//         "end_index": 880,
//         "device_watts": false,
//         "average_watts": 176.1,
//         "average_heartrate": 123.7,
//         "max_heartrate": 148.0,
//         "segment": {
//             "id": 16893859,
//             "resource_state": 2,
//             "name": "Goose Creek Climb",
//             "activity_type": "Ride",
//             "distance": 3084.0,
//             "average_grade": 1.8,
//             "maximum_grade": 35.2,
//             "elevation_high": 292.2,
//             "elevation_low": 235.8,
//             "start_latlng": [
//                 39.349988,
//                 -86.455119
//             ],
//             "end_latlng": [
//                 39.33981,
//                 -86.423233
//             ],
//             "elevation_profile": null,
//             "climb_category": 0,
//             "city": "Martinsville",
//             "state": "Indiana",
//             "country": "United States",
//             "private": false,
//             "hazardous": false,
//             "starred": false
//         },
//         "pr_rank": 3,
//         "achievements": [
//             {
//                 "type_id": 3,
//                 "type": "pr",
//                 "rank": 3
//             }
//         ],
//         "kom_rank": null,
//         "hidden": false
//     },
