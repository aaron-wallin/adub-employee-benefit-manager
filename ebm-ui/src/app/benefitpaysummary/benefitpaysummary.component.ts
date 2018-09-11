import { Component, OnInit, Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeDataService } from '../services/employee.data.service';

@Component({
  selector: 'ebm-benefitpaysummary-view',
  templateUrl: './benefitpaysummary.component.html',
  styleUrls: ['./benefitpaysummary.component.scss']
})

@Injectable()
export class BenefitPaySummaryComponent implements OnInit {

    title: string;
    benefitPaySummaryData: any;
    deductionData: any;
    employeeId: string;

    constructor(private _employeeDataService: EmployeeDataService,
                private _routeParams: ActivatedRoute) {
        this.employeeId = this._routeParams.snapshot.params['id'];
        this.title = 'Employee Benefit Pay Summary';
    }

    ngOnInit(): void {
        this.loadData();
    }

    private loadData() {
        this._employeeDataService.getEmployeeBenefitPaySummary(this.employeeId).subscribe(({data}) => {
            this.benefitPaySummaryData = data.employee;

            const dedKeys = Object.keys(this.benefitPaySummaryData.paycheck.deductions);

            const goodDeductions = [];
            dedKeys.forEach(d => {
                console.log(this.benefitPaySummaryData.paycheck.deductions[d]);
                goodDeductions.push(this.benefitPaySummaryData.paycheck.deductions[d]);
            });

            this.deductionData = goodDeductions;
        });
    }
}
