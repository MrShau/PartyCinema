import { Route, Routes } from "react-router-dom";
import AppRoutes from "./AppRoutes";
import { useContext, useEffect, useState } from "react";
import { Context } from "./main";
import UserApi from "./api/UserApi";
import { Spinner } from "react-bootstrap";

export default function App() {

    const stores = useContext(Context);
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        if (localStorage.getItem("token") == null) {
            stores?.user.setUser(null);
            stores?.user.setIsAuth(false);
            setLoading(false);
        }
        else {
            UserApi.auth().then((res) => {
                if (res == null)
                    return;
                stores?.user.setUser(res);
                stores?.user.setIsAuth(true);
                setLoading(false);
            }).catch(() => {
                stores?.user.setUser(null);
                stores?.user.setIsAuth(false);
                setLoading(false);
            });
        }
        
    }, []);

    return (
        loading ?
            <div className="w-100 vh-100 p-0 m-0 d-flex align-items-center justify-content-center">
                <Spinner animation="grow" className="bg-primary"/>
            </div>
            :
            <Routes>
                {
                    AppRoutes.map((route, index) => {
                        let { element, ...props } = route;
                        return <Route key={index} element={element} {...props} />
                    })
                }
            </Routes>
    )
}