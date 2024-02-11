import Auth from "./pages/auth/Auth";
import Home from "./pages/home/Home";

const AppRoutes =
[
    {
        index: true,
        element: <Home />
    },
    {
        path: 'auth',
        element: <Auth />
    }
]    

export default AppRoutes;