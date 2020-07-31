import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { appRoutes } from './routes';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeResolver } from './resolvers/employee-list.resolver';

@NgModule({
  declarations: [AppComponent, NavMenuComponent, EmployeeListComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [EmployeeResolver],
  bootstrap: [AppComponent],
})
export class AppModule {}
