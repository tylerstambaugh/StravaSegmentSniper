import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import SegmentSniper from "./components/segment-sniper/main";
import Activity from "./components/segment-sniper/activity/Activity";
import Athlete from "./components/segment-sniper/athlete/Athlete";

const AppRoutes = [
  {
    index: true,
    requireAuth: false,
    path: "/",
    element: <SegmentSniper />,
  },
  {
    path: "/activity/",
    requireAuth: true,
    element: <Activity />,
  },
  {
    path: "/athlete/",
    requireAuth: true,
    element: <Athlete />,
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
