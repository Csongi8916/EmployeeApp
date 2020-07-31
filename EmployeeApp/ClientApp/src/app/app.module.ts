import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { appRoutes } from './routes';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeListResolver } from './resolvers/employee-list.resolver';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { EmployeeResolver } from './resolvers/employee.resolver';

@NgModule({
  declarations: [AppComponent, NavMenuComponent, EmployeeListComponent, EmployeeDetailComponent, EmployeeEditComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [EmployeeListResolver, EmployeeResolver],
  bootstrap: [AppComponent],
})
export class AppModule {}
