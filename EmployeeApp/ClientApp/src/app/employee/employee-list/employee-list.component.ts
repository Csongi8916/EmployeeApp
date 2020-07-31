import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from 'src/app/services/employee.service';
import { Employee } from 'src/app/models/employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[];

  constructor(private route: ActivatedRoute, private employeeService: EmployeeService) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.employees = data['employees'];
    });
  }

  deleteEmployee(event: any) {
    this.employeeService.deleteEmployee(event.target.id).subscribe(
      (next) => {
        let index = 0;
        for (let i = 0; i < this.employees.length; i++) {
          if (+this.employees[i].id === +event.target.id) {
            index = i;
            break;
          }
        }

        this.employees.splice(index, 1);
        console.log('Employee deleted successfully!');
      },
      (error) => {
        console.log(error);
      },
    );
  }
}
