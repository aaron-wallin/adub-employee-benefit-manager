import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { EmployeeModel } from '../employee/employee.model';
import { DependentModel } from '../dependent/dependent.model';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import 'rxjs/add/operator/map';

@Injectable()
export class EmployeeDataService {
    private getEmployeeListQuery = gql`
        {
            employees {
                employeeId
                firstName
                lastName
            }
        }`;

    private getEmployee = gql`
    {
        employee(employeeId: $empId) {
            employeeId
            firstName
            lastName
        }
    }`;


    constructor (private _http: Http, private _apollo: Apollo) { }

    /*
    getEmployee(employeeId: string): EmployeeModel {
        const emp: EmployeeModel = new EmployeeModel();
        this._apollo.query({query: this.getEmployeeList, variables: {empId: employeeId}}).subscribe(({data}) => {
            const employeeData = data.employee;
        });
    }
    */

    getEmployeeList(): EmployeeModel[] {
        const employees: Array<EmployeeModel> = new Array<EmployeeModel>();

        this._apollo.query({query: this.getEmployeeListQuery}).subscribe(({data}) => {
            const employeeData = data.employees;

            employeeData.forEach(element => {
                employees.push( {
                    FirstName: element.firstName,
                    LastName: element.lastName,
                    EmployeeId: element.employeeId,
                    Dependents: new Array<DependentModel>()
                } );
            });
        });

        return employees;
    }
}
