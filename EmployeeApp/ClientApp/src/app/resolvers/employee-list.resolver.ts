import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee';

@Injectable()
export class EmployeeResolver implements Resolve<Employee[]> {
  constructor(private employeeService: EmployeeService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Employee[]> {
    return this.employeeService.getEmployees().pipe(
      catchError((error) => {
        console.log(error);
        this.router.navigate(['/']);
        return of(null);
      }),
    );
  }
}
