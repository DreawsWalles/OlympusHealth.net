import React, {useState} from "react";
import classes from "./SysAdminLayout.module.css";
import Logo from "../../Images/logo.svg";
import Menu from "../../../Components/Menu/SysAdmin/Menu";
import StartScreen from "../StartScreen/StartScreen";


export default function SysAdminLayout(){
    const [countNotification, setCountNotification] = useState(0);
    const [content, setContent] = useState(<StartScreen />);
    function clickOnLogo(){
        setContent(<StartScreen />)
    }

    return (
        <div className={classes.content}>
            <div onClick={clickOnLogo} className={classes.head}>
                <img src={Logo}/>
            </div>
            <Menu setContent={setContent} countNotification={countNotification} setCountNotification={setCountNotification}/>
            {content}
        </div>
    )
}