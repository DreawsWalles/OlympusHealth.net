import React, {useState} from "react";
import classes from "./SysAdminLayout.module.css";
import Logo from "../../Images/logo.svg";
import Menu from "../Menu/Menu";


export default function SysAdminLayout(){
    const [countNotifications, setCountNotifications] = useState(0);
    return (
        <div className={classes.content}>
            <div className={classes.head}>
                <img src={Logo}/>
            </div>
            <Menu />
        </div>
    )
}