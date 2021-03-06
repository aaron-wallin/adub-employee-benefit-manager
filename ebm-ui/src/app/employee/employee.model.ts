import { DependentModel } from '../dependent/dependent.model';

export class EmployeeModel {
    employeeId: string;
    firstName: string;
    lastName: string;
    dependents: DependentModel[];

    constructor() {
        this.employeeId = '';
        this.firstName = '';
        this.lastName = '';
        this.dependents = new Array<DependentModel>();
    }
}
