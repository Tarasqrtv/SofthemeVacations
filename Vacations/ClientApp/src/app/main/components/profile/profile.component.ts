import { Component, OnInit } from '@angular/core';

import { EmployeeService } from '../../services/employee.service';
import { Employee } from './employee.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent implements OnInit {
  title = 'profile';
  employee: Employee;
  
  constructor(private service: EmployeeService) { }

  ngOnInit() {
    this.service.getEmployee().subscribe(response => this.employee = response);
  }


}
