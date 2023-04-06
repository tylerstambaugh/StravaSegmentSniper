import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import SegmentSniper from "./components/segment-sniper/main";
import Activity from "./components/segment-sniper/activity/Activity";
import Athlete from "./components/segment-sniper/athlete/Athlete";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/counter",
    element: <Counter />,
  },
  {
    path: "/fetch-data",
    requireAuth: true,
    element: <FetchData />,
  },
  {
    path: "/segment-sniper/*",
    requireAuth: true,
    element: <SegmentSniper />,
  },
  {
    path: "/segment-sniper/activity/",
    requireAuth: true,
    element: <Activity />,
  },
  {
    path: "/segment-sniper/athlete/",
    requireAuth: true,
    element: <Athlete />,
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
