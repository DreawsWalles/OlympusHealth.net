import type {GenderModel} from "./GenderModel";

export class PatientModel
{
    id: string;
    login: string;
    phoneNumber: string | null;
    email: string | null;
    name: string;
    surname: string;
    patronymic: string | null;
    birthday: string | null;
    accept: boolean;
    gender: GenderModel;
    outpatientCards: [];
    researchAreas: [];

    constructor(id: string, login: string,
                name: string, surname: string,
                birthday: string | null, accept: boolean,
                gender: GenderModel, patronymic: string | null,
                email: string | null, phoneNumber: string | null, outpatientCards: [], researchAreas: []) {
        this.id = id ?? Error("Not correct parameter id");
        this.login = login ?? Error("Not correct parameter login");
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.name = name ?? Error("Not correct parameter name");
        this.surname = surname ?? Error("Not correct parameter surname");
        this.patronymic = patronymic;
        this.birthday = birthday;
        this.accept = accept ?? Error("Not correct parameter accept");
        this.gender = gender ?? Error("Not correct parameter gender");
        this.outpatientCards = outpatientCards ?? Error("Not correct parameter outpatientCards");
        this.researchAreas = researchAreas ?? Error("Not correct parameter researchAreas");
    }
    Type(): string  {
        return "PatientModel";
    }
}