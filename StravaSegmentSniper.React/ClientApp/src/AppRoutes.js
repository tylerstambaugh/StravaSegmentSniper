import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { SegmentSniper } from "./components/segmentSniper/segment-sniper.js";

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
        path: '/segmentSniper/segment-sniper',
        requireAuth: true,
        element: <SegmentSniper />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
