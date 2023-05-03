export class StreetModel
{
    id: string | null;
    name: string;
    numberOfHouse: string;
    constructor(id: string | null, name: string, numberOfHouse: string) {
        this.id = id;
        this.name = name ?? Error("Error correct parameter name");
        this.numberOfHouse = numberOfHouse ?? Error("Error correct parameter numberOfHouse");
    }
}