import {IRegisterModel} from "./IRegisterModel";

export class RegisterModelSysAdmin extends IRegisterModel
{
    login: string;
    password: string;
    constructor(login: string, password: string) {
        super();
        this.login = login ?? Error("Not correct parameter login");
        this.password = password ?? Error("Error correct parameter password");
    }
    GetRole = () => "sysAdmin";
}
