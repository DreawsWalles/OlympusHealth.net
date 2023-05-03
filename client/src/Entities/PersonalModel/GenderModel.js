export class GenderModel
{
    id: string;
    name: string;
    constructor(id: string, name: string) {
        this.id = id ?? Error("Error correct parameter id");
        this.name = name ?? Error("Error correct parameter name");
    }
    Type(): string {
        return "GenderModel";
    }
}