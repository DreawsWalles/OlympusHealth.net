export class SysAdminModel
{
    id: string;
    login: string;
    accept: boolean;

    constructor(id: string, login: string, accept: boolean) {
        this.id = id ?? Error("Not correct parameter id");
        this.login = login ?? Error("Not correct parameter login");
        this.accept = accept ?? Error("Not correct parameter accept");
    }
    Type(): string {
        return "SysAdminModel"
    }
}