import { Component, OnInit } from '@angular/core';
import { EmployeeDataService } from '../services/employee.data.service';
import { EmployeeListModel } from './employee.model.list';

@Component({
  selector: 'ebm-employee-list',
  templateUrl: './employee.list.component.html',
  styleUrls: ['./employee.list.component.scss']
})

export class EmployeeListComponent implements OnInit {
    employeeList: Array<EmployeeListModel> = new Array<EmployeeListModel>();
    selectedEmployee: any;

    constructor(private _employeeDataService: EmployeeDataService) { }

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
