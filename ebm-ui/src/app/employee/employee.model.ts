import { DependentModel } from '../dependent/dependent.model';

export class EmployeeModel {
    EmployeeId: string;
    FirstName: string;
    LastName: string;
    Dependents: DependentModel[];
}
