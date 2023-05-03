export class RegionModel
{
    id: string | null;
    name: string;
    constructor(id: string | null, name: string) {
        this.id = id;
        this.name = name ?? Error("Not correct parameter name");
    }
}