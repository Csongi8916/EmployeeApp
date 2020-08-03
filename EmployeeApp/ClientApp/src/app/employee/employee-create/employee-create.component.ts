import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Organization } from 'src/app/models/organization';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css'],
})
export class EmployeeCreateComponent implements OnInit {
  employee: Employee;
  superiors: Employee[];
  organizations: Organization[];
  isUpdated: boolean;

  constructor(private route: ActivatedRoute, private router: Router, private employeeService: EmployeeService) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.employee = data['employee'];
      this.superiors = data['employee'].superiors;
      this.organizations = data['employee'].organizationUnits;
    });
    this.isUpdated = false;
  }

  createEmployee(event: any) {
    if (event.name !== null && event.name !== undefined) {
      this.employeeService.createEmployee(this.employee).subscribe(
        (next) => {
          console.log('Employee created successfully!');
          this.router.navigate(['/']);
        },
        (error) => {
          console.log(error);
        },
      );
    }
  }
}
