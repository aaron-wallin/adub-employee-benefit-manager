import { Component, OnInit, Injectable } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { EmployeeDataService } from '../services/employee.data.service';
import { EmployeeModel } from './employee.model';
import { DependentModel } from '../dependent/dependent.model';

@Component({
  selector: 'ebm-employee-edit',
  templateUrl: './employee.edit.component.html',
  styleUrls: ['./employee.edit.component.scss']
})

@Injectable()
export class EmployeeEditComponent implements OnInit {

    employeeId: string;
    currentEmployee: EmployeeModel;
    currentEditDependent: DependentModel;
    title: string;
    isAdd: boolean;

    constructor(private _routeParams: ActivatedRoute,
                private _route: Router,
                private _employeeDataService: EmployeeDataService) {

        const path = this._route.url;

        this.currentEmployee = new EmployeeModel();

        if (path.startsWith('/employee/edit')) {
            this.employeeId = this._routeParams.snapshot.params['id'];
            this.title = 'Editing Employee';
            this.isAdd = false;
        } else {
            this.employeeId = '';
            this.title = 'Add New Employee';
            this.isAdd = true;
        }
    }

    addDependent(): void {
        this.currentEditDependent = new DependentModel();
        this.currentEmployee.dependents.push(this.currentEditDependent);
    }

    deleteDependent(dependent: any) {
        const index = this.currentEmployee.dependents.indexOf(dependent, 0);
        if (index > -1 ) {
            this.currentEmployee.dependents.splice(index, 1);
        }
    }

    selectDependentForEdit(dependent: any) {
        this.currentEditDependent = dependent;
    }

    saveEmployee() {
        this._employeeDataService.saveEmployee(this.currentEmployee).subscribe(({data}) => {
            const employeeData = data.saveEmployee;
            this.currentEmployee.employeeId = employeeData.employeeId;

            if (this.isAdd) {
                this._route.navigate(['/employee/edit', this.currentEmployee.employeeId]);
            }
        });
    }

    ngOnInit(): void {
        if (this.isAdd) {
            this.currentEmployee = new EmployeeModel();
        } else {
            this._employeeDataService.getEmployee(this.employeeId).subscribe(({data}) => {
                const employeeData = data.employee;
                this.currentEmployee.employeeId = employeeData.employeeId;
                this.currentEmployee.firstName = employeeData.firstName;
                this.currentEmployee.lastName = employeeData.lastName;

                employeeData.dependents.forEach(d => {
                    this.currentEmployee.dependents.push({
                        firstName: d.firstName,
                        lastName: d.lastName
                    });
                });
            });
        }
    }
}
