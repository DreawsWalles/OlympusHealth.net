import {CheckLogin} from "../Swapi/SwapiAccount/SwapiAccount";

export default async function GenerateLogin(){
    let rug = require('random-username-generator');
    while (true) {
        let username = rug.generate();
        let tmp = await CheckLogin(username);
        if (!tmp)
            return username;
    }
}