import {Navigate} from "react-router-dom";
import {useEffect} from "react";
import {GetRole} from "../../Swapi/SwapiAccount";

export default function SysAdminNavigation(){
    useEffect(() =>
    {
        (()=> {
            // eslint-disable-next-line no-restricted-globals
            location.reload();
            })();
    },[]);
    return (<div>Ну что ж</div> )
}