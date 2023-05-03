export class RoleModel
{
    id: string;
    name: string;
    constructor(id: string, name: string) {
        this.id = id ?? Error("Not correct parameter id");
        this.name = name ?? Error("Not correct parameter name");
    }
    Type(): string  {
        return "RoleModel";
    }
}