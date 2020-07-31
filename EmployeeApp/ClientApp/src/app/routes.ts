import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeListResolver } from './resolvers/employee-list.resolver';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { EmployeeEditResolver } from './resolvers/employee.edit.resolver';
import { EmployeeCreateComponent } from './employee/employee-create/employee-create.component';
import { EmployeeCreateResolver } from './resolvers/employee.create.resolver';

export const appRoutes: Routes = [
  { path: '', component: EmployeeListComponent, resolve: { employees: EmployeeListResolver } },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    children: [
      {
        path: 'detail/:id',
        component: EmployeeDetailComponent,
        resolve: { employee: EmployeeEditResolver },
      },
      {
        path: 'edit/:id',
        component: EmployeeEditComponent,
        resolve: { employee: EmployeeEditResolver },
      },
      {
        path: 'create',
        component: EmployeeCreateComponent,
        resolve: { employee: EmployeeCreateResolver },
      },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
