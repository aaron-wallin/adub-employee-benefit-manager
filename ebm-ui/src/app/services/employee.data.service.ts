import { Injectable } from '@angular/core';
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

    private getEmployeeBenefitPaySummaryQuery = gql`
        query Employee($employeeId: String) {
            employee(employeeId: $employeeId) {
              employeeId
              firstName
              lastName
              benefitInfo {
                baseAnnualCost
                discountApplied
                discountedAnnualCost
              }
              benefitInfoSummary {
                baseAnnualCost
                discountApplied
                discountedAnnualCost
              }
              paycheck {
                grossAmount
                netAmount
                deductions
              }
              dependents {
                firstName
                lastName
                benefitInfo {
                  baseAnnualCost
                  discountApplied
                  discountedAnnualCost
                }
              }
            }
          }`;

    constructor (private _apollo: Apollo) { }

    saveEmployee(employeeData: any) {
        const employee = employeeData;
        return this._apollo.mutate({
            mutation: this.saveEmployeeMutation,
            variables: {
                employee
            }
        });
    }

    getEmployeeBenefitPaySummary(employeeId: string): any {
        return this._apollo.query({
            query: this.getEmployeeBenefitPaySummaryQuery,
            variables: {
                employeeId: employeeId
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
