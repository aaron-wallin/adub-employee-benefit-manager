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
                dependentCount
            }
        }`;

    private getEmployeeQuery = gql`
        query Employee($employeeId: String) {        
            employee(employeeId: $employeeId) {
                employeeId
                firstName
                lastName
                dependents {
                    firstName
                    lastName
                }
            }
        }`;

    private saveEmployeeMutation = gql`
        mutation SaveEmployee($employee:EmployeeInput!) {
            saveEmployee(employee: $employee)
            {
                employeeId                
            }
        } `;

    constructor (private _http: Http, private _apollo: Apollo) { }

    saveEmployee(employeeData: any) {
        const employee = employeeData;
        return this._apollo.mutate({
            mutation: this.saveEmployeeMutation,
            variables: {
                employee
            }
        });
    }

    getEmployee(employeeId: string): any {
        return this._apollo.query({
            query: this.getEmployeeQuery,
            variables: {
                employeeId: employeeId
            }
        });
    }

    getEmployeeList(): any {
        return this._apollo.query({
            query: this.getEmployeeListQuery
        });
    }
}
