import {ChiefOfMedicineModel} from "../../Entities/PersonalModel/ChiefOfMedicineModel";
import {DoctorModel} from "../../Entities/PersonalModel/DoctorModel";
import {HeadOfDepartmentModel} from "../../Entities/PersonalModel/HeadOfDepartmentModel";
import {MedicRegistrationModel} from "../../Entities/PersonalModel/MedicRegistratorModel";
import {PatientModel} from "../../Entities/PersonalModel/PatientModel";
import {SysAdminModel} from "../../Entities/PersonalModel/SysAdminModel";

export class AllUsers {
    chiefsOfMedicine: ChiefOfMedicineModel[] = [];
    doctors: DoctorModel[] = [];
    headOfDepartments: HeadOfDepartmentModel[] = [];
    medicRegistrations: MedicRegistrationModel[] = [];
    patients: PatientModel[] = [];
    sysAdmins: SysAdminModel[] = [];

    constructor(chiefsOfMedicine: ChiefOfMedicineModel[],
                doctors: DoctorModel[],
                headOfDepartments: HeadOfDepartmentModel[],
                medicRegistrations: MedicRegistrationModel[],
                patients: PatientModel[],
                sysAdmins: SysAdminModel[]) {
        this.chiefsOfMedicine = chiefsOfMedicine;
        this.doctors = doctors;
        this.headOfDepartments = headOfDepartments;
        this.medicRegistrations = medicRegistrations;
        this.patients = patients;
        this.sysAdmins = sysAdmins;
    }
    count(): number{
        return this.chiefsOfMedicine.length + this.doctors.length + this.headOfDepartments.length + this.medicRegistrations.length + this.patients.length + this.sysAdmins.length;
    }
    filter(filter: string):AllUsers{
        let sysAdmins = this.sysAdmins.filter(element => element.login.search(filter) === 0);
        let chiefsOfMedicine = this.chiefsOfMedicine.filter(element => element.login.search(filter) === 0);
        let doctors = this.doctors.filter(element => element.login.search(filter) === 0);
        let headOfDepartments = this.headOfDepartments.filter(element => element.login.search(filter) === 0);
        let medicRegistrations = this.medicRegistrations.filter(element => element.login.search(filter) === 0);
        let patients = this.patients.filter(element => element.login.search(filter) === 0);
        return new AllUsers(chiefsOfMedicine, doctors, headOfDepartments, medicRegistrations, patients, sysAdmins);
    }
    checkingAccept(other: AllUsers): boolean{
        for(let i = 0; i < other.sysAdmins.length; i++){
            if(this.sysAdmins[i].accept === other.sysAdmins[i].accept){
                return true;
            }
        }
        for(let i = 0; i < other.chiefsOfMedicine.length; i++){
            if(this.chiefsOfMedicine[i].accept === other.chiefsOfMedicine[i].accept){
                return true;
            }
        }
        for(let i = 0; i < other.doctors.length; i++){
            if(this.doctors[i].accept === other.doctors[i].accept){
                return true;
            }
        }
        for(let i = 0; i < other.headOfDepartments.length; i++){
            if(this.headOfDepartments[i].accept === other.headOfDepartments[i].accept){
                return true;
            }
        }
        for(let i = 0; i < other.medicRegistrations.length; i++){
            if(this.medicRegistrations[i].accept === other.medicRegistrations[i].accept){
                return true;
            }
        }
        for(let i = 0; i < other.patients.length; i++){
            if(this.patients[i].accept === other.patients[i].accept){
                return true;
            }
        }
        return false;
    }
}