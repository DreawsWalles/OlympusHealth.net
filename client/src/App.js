import React, {Component, useEffect} from "react";
import {
    BrowserRouter as Router,
    Routes,
    Route
} from 'react-router-dom';
import IsAutorize from './Navigation'
import Authorization from "./Screens/Autorize/Autorization/Authorization";
import Registration from "./Screens/Autorize/Registration/Registration";
import {useCookies} from "react-cookie";
import {Stub} from "./Screens/Medic/Stub/Stub";


export default function App(props) {
    const [cookie, setCookie] = useCookies(["user"]);
    //setCookie("user","");
    return (
        <Router>
            <Routes>
                <Route path="/" element={<IsAutorize />} />
                <Route path="/Authorization" element={<Authorization />} />
                <Route path="/Registration" element={<Registration />} />
                <Route path="/Stub" element={<Stub />} />
            </Routes>
        </Router>
    );
  }


