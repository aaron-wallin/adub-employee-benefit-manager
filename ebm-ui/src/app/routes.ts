import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee.list.component';
import { EmployeeEditComponent } from './employee/employee.edit.component';
import { BenefitPaySummaryComponent } from './benefitpaysummary/benefitpaysummary.component';

export const appRoutes: Routes = [
    { path: 'employees', component: EmployeeListComponent },
    { path: 'employee/edit/:id', component: EmployeeEditComponent },
    { path: 'employee/summary/:id', component: BenefitPaySummaryComponent },
    { path: 'employee/add', component: EmployeeEditComponent },
    { path: '', redirectTo: 'employees', pathMatch: 'full' }
];
