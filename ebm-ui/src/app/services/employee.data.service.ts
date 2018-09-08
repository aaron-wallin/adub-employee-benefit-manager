import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { EmployeeModel } from '../employee/employee.model';
import { DependentModel } from '../dependent/dependent.model';


@Injectable()
export class EmployeeDataService {
    constructor (private _http: Http) { }

    getEmployeeList(): EmployeeModel[] {
        const employees: Array<EmployeeModel> = new Array<EmployeeModel>();
        employees.push( {
            FirstName: 'Aaron',
            LastName: 'Wallin',
            EmployeeId: 'test1',
            Dependents: new Array<DependentModel>()
        } );
        employees.push( {
            FirstName: 'Jon',
            LastName: 'Smith',
            EmployeeId: 'test2',
            Dependents: new Array<DependentModel>()
        } );
        return employees;
    }
}
