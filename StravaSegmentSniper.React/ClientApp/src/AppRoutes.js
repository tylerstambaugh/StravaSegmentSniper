import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import SegmentSniper from "./components/segment-sniper/main";
import Activity from "./components/segment-sniper/scenes/activity/Activity";
import Athlete from "./components/segment-sniper/scenes/athlete/Athlete";
import TokenScene from "./components/segment-sniper/scenes/token/tokenScene";

const AppRoutes = [
  {
    index: true,
    requireAuth: false,
    path: "/",
    element: <SegmentSniper />,
  },
  {
    path: "/activities/",
    requireAuth: true,
    element: <Activity />,
  },
  {
    path: "/athlete/",
    requireAuth: true,
    element: <Athlete />,
  },
  {
    path: "/token-maintenance/",
    requireAuth: true,
    element: <TokenScene />,
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
