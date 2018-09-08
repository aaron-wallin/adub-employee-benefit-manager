import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavMainComponent } from './nav/navmain.component';
import { EmployeeListComponent } from './employee/employee.list.component';
import { EmployeeEditComponent } from './employee/employee.edit.component';

import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { EmployeeDataService } from './services/employee.data.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMainComponent,
    EmployeeListComponent,
    EmployeeEditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    EmployeeDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
