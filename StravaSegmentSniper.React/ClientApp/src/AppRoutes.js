import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import Activity from './components/segment-sniper/activity/Activity';
import  SegmentSniper from "./components/segment-sniper/main.js";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        requireAuth: true,
        element: <FetchData />
    },
    {
        path: '/segment-sniper/main/*',
        requireAuth: true,
        element: <SegmentSniper />
    },
    {
        path: '/segment-sniper/activity/Activity',
        requireAuth: true,
        element: <Activity />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
