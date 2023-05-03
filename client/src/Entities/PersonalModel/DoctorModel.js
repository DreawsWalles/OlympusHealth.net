import type {GenderModel} from "./GenderModel";
import type {StreetModel} from "../AddressModel/StreetModel";

export class DoctorModel
{
    id: string;
    login: string;
    name: string;
    surname: string;
    patronymic: string | null;
    email: string;
    dateEmployment: string;
    dateDismissal: string | null;
    phoneNumber: string | null;
    dateBirthday: string | null;
    department;
    gender: GenderModel;
    Address: StreetModel | null;
    files: [] | null;
    placeOfStudies: [] | null;
    descriptionHeadOfDepartment: [] | null;
    accessRights: [] | null;
    accept: boolean

    constructor(id: string,
                login: string,
                name: string,
                surname: string,
                patronymic: string | null,
                email: string,
                dateEmployment: string,
                dateDismissal: string | null,
                phoneNumber: string | null,
                dateBirthday: string | null,
                department,
                gender: GenderModel,
                Address: StreetModel | null,
                files: [] | null,
                placeOfStudies: [] | null,
                descriptionHeadOfDepartment: [] | null,
                accessRights: [] | null,
                accept: boolean) {
        this.id = id ?? Error("Not correct parameter id");
        this.login = login ?? Error("Not correct parameter login");
        this.name = name ?? Error("Not correct parameter name");
        this.surname = surname ?? Error("Not correct parameter surname");
        this.patronymic = patronymic;
        this.email = email;
        this.dateEmployment = dateEmployment;
        this.dateDismissal = dateDismissal;
        this.phoneNumber = phoneNumber;
        this.dateBirthday = dateBirthday;
        this.gender = gender ?? Error("Not correct parameter gender");
        this.Address = Address;
        this.files = files;
        this.placeOfStudies = placeOfStudies;
        this.descriptionHeadOfDepartment = descriptionHeadOfDepartment;
        this.accessRights = accessRights;
        this.accept = accept ?? Error("Not correct parameter accept");
        this.department = department;
    }
    Type(): string {
        return "DoctorModel"
    }
}