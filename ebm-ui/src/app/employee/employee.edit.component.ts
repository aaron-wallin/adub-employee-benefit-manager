import { Component, OnInit, Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeDataService } from '../services/employee.data.service';
import { EmployeeModel } from './employee.model';

@Component({
  selector: 'ebm-employee-edit',
  templateUrl: './employee.edit.component.html',
  styleUrls: ['./employee.edit.component.scss']
})

@Injectable()
export class EmployeeEditComponent implements OnInit {

    employeeId: string;
    employees: Array<EmployeeModel>;

    constructor(private _routeParams: ActivatedRoute,
                private _employeeDataService: EmployeeDataService) {
        this.employeeId = this._routeParams.snapshot.params['id'];
        console.log(this.employeeId);
    }

    ngOnInit(): void {
        this.employees = this._employeeDataService.getEmployeeList();
    }
}
