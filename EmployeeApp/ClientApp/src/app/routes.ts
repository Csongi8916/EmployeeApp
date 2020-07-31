import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeListResolver } from './resolvers/employee-list.resolver';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { EmployeeResolver } from './resolvers/employee.resolver';

export const appRoutes: Routes = [
  { path: '', component: EmployeeListComponent, resolve: { employees: EmployeeListResolver } },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    children: [
      {
        path: 'detail/:id',
        component: EmployeeDetailComponent,
        resolve: { employee: EmployeeResolver },
      },
      {
        path: 'edit/:id',
        component: EmployeeEditComponent,
        resolve: { employee: EmployeeResolver },
      },
      {
        path: 'create',
        component: EmployeeEditComponent,
      },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
