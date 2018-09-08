import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee.list.component';
import { EmployeeEditComponent } from './employee/employee.edit.component';

export const appRoutes: Routes = [
    { path: 'employees', component: EmployeeListComponent },
    { path: 'employee/:id', component: EmployeeEditComponent },
    { path: '', redirectTo: 'employees', pathMatch: 'full' }
];
