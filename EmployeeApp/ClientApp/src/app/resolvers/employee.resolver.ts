import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Employee } from '../models/employee';
import { EmployeeService } from '../services/employee.service';

@Injectable()
export class EmployeeResolver implements Resolve<Employee[]> {
  constructor(private employeeService: EmployeeService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Employee[]> {
    return this.employeeService.getEmployee(route.params['id']).pipe(
      catchError((error) => {
        console.log(error);
        this.router.navigate(['/']);
        return of(null);
      }),
    );
  }
}
