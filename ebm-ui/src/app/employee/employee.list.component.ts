import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeDataService } from '../services/employee.data.service';
import { EmployeeModel } from './employee.model';

@Component({
  selector: 'ebm-employee-list',
  templateUrl: './employee.list.component.html',
  styleUrls: ['./employee.list.component.scss']
})

export class EmployeeListComponent implements OnInit {
    employees: Array<EmployeeModel> =  new Array<EmployeeModel>();

    constructor(private _routeParams: ActivatedRoute,
                private _employeeDataService: EmployeeDataService) {
                }

    ngOnInit(): void {
        this.employees = this._employeeDataService.getEmployeeList();
    }
}
