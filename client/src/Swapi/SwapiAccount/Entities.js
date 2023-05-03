export class AnswerAutorize{
    name: string;
    role: string;
    token: string;
    status: number;
    constructor(name: string, role: string, token: string, status: number) {
        debugger
        this.name = name ?? Error("Not correct parameter name");
        this.role = role ?? Error("Not correct parameter role");
        this.token = token ?? Error("Not correct parameter token");
        this.status = status ?? Error("Not correct parameter status");
    }
}