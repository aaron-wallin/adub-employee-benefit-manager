import { Component, OnInit, Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    employees: Array<EmployeeModel>;
    currentEmployee: EmployeeModel;
    title: string;
    isAdd: boolean;

    constructor(private _routeParams: ActivatedRoute,
                private _route: Router,
                private _employeeDataService: EmployeeDataService) {

        const path = this._route.url;

        this.currentEmployee = new EmployeeModel();

        if (path.startsWith('/employee/edit')) {
            this.employeeId = this._routeParams.snapshot.params['id'];
            this.title = 'Editing Employee: ' + this.employeeId + ' ' + this.currentEmployee.FirstName;
            this.isAdd = false;
        } else {
            this.employeeId = '';
            this.title = 'Add New Employee';
            this.isAdd = true;
        }
    }

    addDependent(): void {
        console.log(this.currentEmployee.Dependents);
        this.currentEmployee.Dependents.push(new DependentModel());
        console.log(this.currentEmployee.Dependents);
    }

    ngOnInit(): void {
        if (this.isAdd) {
            this.currentEmployee = new EmployeeModel();
        } else {
            this.employees = this._employeeDataService.getEmployeeList();
        }
    }
}
