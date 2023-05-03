import type {ChiefOfMedicineModel} from "../../../Entities/PersonalModel/ChiefOfMedicineModel";
import type {DoctorModel} from "../../../Entities/PersonalModel/DoctorModel";
import type {HeadOfDepartmentModel} from "../../../Entities/PersonalModel/HeadOfDepartmentModel";
import type {MedicRegistrationModel} from "../../../Entities/PersonalModel/MedicRegistratorModel";
import type {PatientModel} from "../../../Entities/PersonalModel/PatientModel";
import type {SysAdminModel} from "../../../Entities/PersonalModel/SysAdminModel";

export class EntityRow
{
    key: string;
    login: string;
    role: string;
    accept: boolean;
    constructor(entity: ChiefOfMedicineModel | DoctorModel | HeadOfDepartmentModel | MedicRegistrationModel | PatientModel | SysAdminModel) {
        this.key = entity.id;
        this.login = entity.login;
        this.accept = entity.accept;
        switch (entity.Type())
        {
            case "ChiefOfMedicineModel":
                this.role = "Главврач";
                break;
            case "DoctorModel":
                this.role = "Врач";
                break;
            case "HeadOfDepartmentModel":
                this.role = "Заведующий отделением";
                break;
            case "MedicRegistrationModel":
                this.role = "Медицинский регистратор";
                break;
            case "PatientModel":
                this.role = "Пациент";
                break;
            case "SysAdminModel":
                this.role = "Системный администратор";
                break
        }
    }
}