import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeDataService } from '../services/employee.data.service';
import { EmployeeModel } from './employee.model';
import { EmployeeListModel } from './employee.model.list';
import { DependentModel } from '../dependent/dependent.model';

@Component({
  selector: 'ebm-employee-list',
  templateUrl: './employee.list.component.html',
  styleUrls: ['./employee.list.component.scss']
})

export class EmployeeListComponent implements OnInit {
    employeeList: Array<EmployeeListModel> = new Array<EmployeeListModel>();
    selectedEmployee: any;

    constructor(private _routeParams: ActivatedRoute,
                private _employeeDataService: EmployeeDataService) {
                }

    ngOnInit(): void {
        this._employeeDataService.getEmployeeList().subscribe(({data}) => {
            data.employees.forEach(element => {
                this.employeeList.push( {
                    firstName: element.firstName,
                    lastName: element.lastName,
                    employeeId: element.employeeId,
                    dependentCount: element.dependentCount
                } );
            });
        });
    }

    setSelected(employee: any) {
        this.selectedEmployee = employee;
    }
}
