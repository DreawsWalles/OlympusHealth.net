export class LoginModel
{
    login: string;
    password: string;
    constructor(login: string, password: string) {
        this.login = login ?? Error("Not correct parameter login");
        this.password = password ?? Error("Error correct parameter password");
    }
}