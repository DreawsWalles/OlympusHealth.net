import {useEffect, useState} from "react";
import {GetRole, IsAccept} from "../../Swapi/SwapiAccount";
import {Navigate} from "react-router-dom";
import {useCookies} from "react-cookie";

export default function Navigation(props) {

    const [isAutorize, setIsAutorize] = useState(true);
    const [cookie, setCookie] = useCookies(["user"]);
    const [role, setRole] = useState("");
    useEffect(() =>
    {
        (async ()=> {
            let tmp = cookie;
            debugger
            if(document.cookie === ""){
                setIsAutorize(false)
            }
            else {
                debugger
                setIsAutorize(true);
                let t = await GetRole(tmp.user);
                setRole(t);
            }
        })();
    },[]);

    if(isAutorize) {
        debugger
        switch (role)
        {
            case "Patient":
                return (<Navigate replace to={"/Patient"} />);
            case "Medic":
                return (<Navigate replace to={"/Medic"} />)
            case "SysAdmin":
                return (<Navigate replace to={"/SysAdmin"} />);
        }
    }
    else {
        return (<Navigate replace to={"/Authorization"} />);
    }
}

