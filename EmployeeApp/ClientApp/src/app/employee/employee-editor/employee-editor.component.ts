import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { Organization } from 'src/app/models/organization';
import { SelectEntity } from 'src/app/models/select-entity';

@Component({
  selector: 'app-employee-editor',
  templateUrl: './employee-editor.component.html',
  styleUrls: ['./employee-editor.component.css'],
})
export class EmployeeEditorComponent implements OnInit {
  @Input() employee: Employee;
  @Input() superiors: SelectEntity[];
  @Input() organizations: SelectEntity[];
  @Output() submit: EventEmitter<Employee> = new EventEmitter<Employee>();

  selectedEmployee: string;
  selectedOrganiztion: string;

  constructor() {}

  ngOnInit() {}

  sumbitEmployee() {
    this.employee.superiorId = this.selectedEmployee;
    this.employee.organizationUnitId = this.selectedOrganiztion;
    this.submit.emit(this.employee);
  }
}
