import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { Organization } from 'src/app/models/organization';
import { SelectEntity } from 'src/app/models/select-entity';

@Component({
  selector: 'app-employee-editor',
  templateUrl: './employee-editor.component.html',
  styleUrls: ['./employee-editor.component.css'],
})
export class EmployeeEditorComponent implements OnInit, AfterViewInit {
  @Input() employee: Employee;
  @Input() superiors: SelectEntity[];
  @Input() organizations: SelectEntity[];
  @Output() submit: EventEmitter<Employee> = new EventEmitter<Employee>();

  @ViewChild('superiorSelect', { static: true }) superiorSelect: ElementRef;

  selectedEmployee: string;
  selectedOrganiztion: string;

  constructor() {}

  ngOnInit() {}

  ngAfterViewInit() {
    this.superiorSelect.nativeElement.value = this.employee.superior;
  }

  sumbitEmployee() {
    this.employee.superiorId = this.selectedEmployee !== null ? +this.selectedEmployee : 0;
    this.employee.organizationUnitId = this.selectedOrganiztion !== null ? +this.selectedOrganiztion : 0;
    this.submit.emit(this.employee);
  }
}
