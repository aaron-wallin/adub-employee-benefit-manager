export class EmployeeListModel {
    employeeId: string;
    firstName: string;
    lastName: string;
    dependentCount: number;

    constructor() {
        this.employeeId = '';
        this.firstName = '';
        this.lastName = '';
        this.dependentCount = 0;
    }
}
