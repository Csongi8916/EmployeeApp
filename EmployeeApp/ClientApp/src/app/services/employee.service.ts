import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + 'employee');
  }

  getEmployee(id: string, mode: string): Observable<Employee> {
    let params = new HttpParams();
    params = params.append('mode', mode);

    return this.http.get<Employee>(this.baseUrl + 'employee/' + id, { params });
  }

  updateEmployee(id: string, employee: Employee) {
    return this.http.put(this.baseUrl + 'employee/' + id, employee);
  }

  createEmployee(employee: Employee) {
    return this.http.post(this.baseUrl + 'employee', employee);
  }

  deleteEmployee(id: number) {
    return this.http.delete(this.baseUrl + 'employee/' + id);
  }
}
