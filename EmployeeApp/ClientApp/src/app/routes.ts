import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeResolver } from './resolvers/employee-list.resolver';

export const appRoutes: Routes = [
  { path: '', component: EmployeeListComponent, resolve: { employees: EmployeeResolver } },
  /*{
    path: '',
    runGuardsAndResolvers: 'always',
    children: [
      {
        path: 'detail/:id',
        component: TodoDetailComponent,
        resolve: { todo: TodoDetailResolver },
      },
      {
        path: 'edit/:id',
        component: TodoEditComponent,
        resolve: { todo: TodoEditResolver },
      },
      {
        path: 'create',
        component: TodoEditComponent,
      },
    ],
  },*/
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
