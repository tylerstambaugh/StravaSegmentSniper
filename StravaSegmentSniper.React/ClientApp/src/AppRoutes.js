import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import SegmentSniper from "./components/segment-sniper/main";
import Activity from "./components/segment-sniper/scenes/activity/Activity";
import Athlete from "./components/segment-sniper/scenes/athlete/Athlete";
import TokenScene from "./components/segment-sniper/scenes/token/tokenScene";
import ConnectWithStrava from "./components/segment-sniper/scenes/connectWithStrava/ConnectWithStrava"
import ConnectWithStravaSuccess from "./components/segment-sniper/scenes/connectWithStrava/ConnectWithStravaSuccess";
import ConnectWithStravaError from "./components/segment-sniper/scenes/connectWithStrava/ConnectWithStravaError";


const AppRoutes = [
  {
    index: true,
    requireAuth: true,
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
    path: "/connect/",
    requireAuth: true,
    element: <ConnectWithStrava />
  },
  {
    path: "/connect-with-strava-success/",
    requireAuth: true,
    element: <ConnectWithStravaSuccess />
  },
  {
    path: "/connect-with-strava-error/",
    requireAuth: true,
    element: <ConnectWithStravaError />
  },

  {
    path: "/token-maintenance/",
    requireAuth: true,
    element: <TokenScene />,
  },
  ...ApiAuthorizationRoutes,
];

export default AppRoutes;
