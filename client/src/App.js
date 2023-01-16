import React, {Component, useEffect} from "react";
import {
    BrowserRouter as Router,
    Routes,
    Route
} from 'react-router-dom';
import IsAutorize from './Screens/Autorize/Navigation'
import Authorization from "./Screens/Autorize/Autorization/Authorization";
import Registration from "./Screens/Autorize/Registration/Registration";
import {useCookies} from "react-cookie";
import MedicNavigation from "./Screens/Medic/Navigation";
import PatientNavigation from "./Screens/Patient/Navigation";
import SysAdminLayout from "./Screens/SysAdmin/SysAdminLayout/SysAdminLayout";


export default function App(props) {
    const [cookie, setCookie] = useCookies(["user"]);
    //setCookie("user","");
    return (
        <Router>
            <Routes>
                <Route path="/" element={<IsAutorize />} />
                <Route path="/Authorization" element={<Authorization />} />
                <Route path="/Registration" element={<Registration />} />
                <Route path="/Medic" element={<MedicNavigation />} />
                <Route path="/Patient" element={<PatientNavigation />} />
                <Route path="/SysAdmin" element={<SysAdminLayout />} />
            </Routes>
        </Router>
    );
  }


