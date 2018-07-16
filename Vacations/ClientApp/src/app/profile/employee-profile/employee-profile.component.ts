import { Component, OnInit } from '@angular/core';

import { GetEmployeeService } from './get-employee.service';
import { Employee } from './employee.model';

@Component({
  selector: 'app-employee-profile',
  templateUrl: './employee-profile.component.html',
  styleUrls: ['./employee-profile.component.css']
})
export class EmployeeProfileComponent implements OnInit {
  employee: Employee;

  constructor(private service: GetEmployeeService) { }

  ngOnInit() {
    this.service.getEmployee().subscribe(response => this.employee = response);
  }

}
