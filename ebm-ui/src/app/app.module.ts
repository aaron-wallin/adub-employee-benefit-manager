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

import { HttpClientModule } from '@angular/common/http';
import { ApolloModule, Apollo } from 'apollo-angular';
import { HttpLinkModule, HttpLink } from 'apollo-angular-link-http';
import { InMemoryCache, NormalizedCacheObject } from 'apollo-cache-inmemory';
import { ApolloCache } from 'apollo-cache';

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
    HttpClientModule,
    ApolloModule,
    HttpLinkModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    EmployeeDataService
  ],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor(apollo: Apollo, httpLink: HttpLink) {
    apollo.create({
      link: httpLink.create({uri: 'http://localhost:60590/api/ebm'}),
      cache: new InMemoryCache() as ApolloCache<NormalizedCacheObject>
    });
  }
}
