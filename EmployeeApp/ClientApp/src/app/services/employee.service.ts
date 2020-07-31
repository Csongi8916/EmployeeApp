import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
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

  getTodo(id: string): Observable<Employee> {
    return this.http.get<Employee>(this.baseUrl + 'employee/' + id);
  }

  updateTodo(id: string, employee: Employee) {
    return this.http.put(this.baseUrl + 'employee/' + id, employee);
  }

  createTodo(employee: Employee) {
    return this.http.post(this.baseUrl + 'employee/', employee);
  }

  deleteTodo(id: number) {
    return this.http.delete(this.baseUrl + 'employee/' + id);
  }
}