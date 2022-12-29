import {useEffect, useState} from "react";
import {GetRole} from "../Swapi/SwapiAccount";
import {Navigate} from "react-router-dom";
import {useCookies} from "react-cookie";

export default function Navigation(props) {

    const [isAutorize, setIsAutorize] = useState(true);
    const [cookie, setCookie] = useCookies(["user"]);
    const [role, setRole] = useState();
    useEffect(() =>
    {
        (async ()=> {
            debugger
            let tmp = cookie;
            if(tmp.user === ""){
                setIsAutorize(false)
            }
            else {
                setIsAutorize(true);
                setRole(await GetRole(tmp.user));
            }
        })();
    },[]);

    if(isAutorize) {
        switch (role)
        {
            case "Patient":
                return (<Navigate replace to={""} />);
            case "Medic":
                return (<Navigate replace to={""} />)
            case "SysAdmin":
                return (<Navigate replace to={""} />);
        }
    }
    else {
        return (<Navigate replace to={"/Authorization"} />);
    }
}

