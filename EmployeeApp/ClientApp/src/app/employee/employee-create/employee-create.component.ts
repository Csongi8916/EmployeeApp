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
      this.employee.id = event.id;
      this.employee.identification = event.identification;
      this.employee.name = event.name;
      this.employee.username = event.username;
      this.employee.password = event.password;
      this.employee.workRole = event.workRole;
      this.employee.phoneNumber = event.phoneNumber;
      this.employee.workRole = event.workRole;
      this.employee.superiorId = event.superiorId;
      this.employee.organizationUnitId = event.organizationUnitId;
    }

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
