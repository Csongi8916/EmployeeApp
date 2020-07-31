import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css'],
})
export class EmployeeDetailComponent implements OnInit {
  employee: Employee;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.employee = data['employee'];
      if (!this.employee.superior) {
        this.employee.superior = this.employee.workRole === 'Ügyvezető igazgató' ? '-' : 'Nincs megadva';
      }
    });
  }
}
