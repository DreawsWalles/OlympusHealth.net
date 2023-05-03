import {GenderModel} from "../PersonalModel/GenderModel";
import type {StreetModel} from "../AddressModel/StreetModel";
import type {CityModel} from "../AddressModel/CityModel";
import type {RegionModel} from "../AddressModel/RegionModel";
import type {CountryModel} from "../AddressModel/CountryModel";
import type {RoleModel} from "../PersonalModel/RoleModel";
import {IRegisterModel} from "./IRegisterModel";

export class RegistrationModelPerson extends IRegisterModel
{
    login: string;
    password: string;
    name: string;
    surname: string;
    patronymic: string;
    email: string;
    phoneNumber: string;
    birthday: string;
    gender: GenderModel;
    role: "patient" | "medic";
    street: StreetModel | null;
    city: CityModel | null;
    region: RegionModel | null;
    country: CountryModel | null;
    roleMedic: RoleModel | null;
    constructor(login: string,
                password: string,
                name: string,
                surname: string,
                patronymic: string,
                email: string,
                phoneNumber: string,
                birthday: string,
                gender: GenderModel,
                role: "patient" | "medic",
                street?: StreetModel | null,
                city?: CityModel | null,
                region?: RegionModel | null,
                country: CountryModel | null,
                roleMedic: RoleModel | null) {
        super();
        this.login = login ?? Error("Not correct parameter login");
        this.password = password ?? Error("Not correct parameter password");
        this.name = name ?? Error("Not correct parameter name");
        this.surname = surname ?? Error("Not correct parameter surname");
        this.patronymic = patronymic ?? Error("Not correct parameter patronymic");
        this.email = email ?? Error("Not correct parameter email");
        this.phoneNumber = phoneNumber ?? Error("Not correct parameter phoneNumber");
        this.birthday = birthday ?? Error("Not correct parameter birthday");
        this.gender = gender  ?? Error("Not correct parameter gender");
        this.role = role  ?? Error("Not correct parameter role");
        if(role === "medic"){
            this.street = street ?? Error("Not correct parameter street");
            this.city = city ?? Error("Not correct parameter city");
            this.region = region ?? Error("Not correct parameter region");
            this.country = country ?? Error("Not correct parameter country");
            this.roleMedic = roleMedic ?? Error("Not correct parameter roleMedic");
        }
    }
    GetRole = (): string => this.role;
}