import { Component, OnInit, Input } from '@angular/core';
import { Employee } from './employee.model';
import { Router } from '@angular/router';
import { EmployeeService } from '../../../services/employee.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})

export class MyProfileComponent implements OnInit {
  title = 'profile';
  
  employee: Employee = <Employee>{};
  
  constructor(private service: EmployeeService, private router: Router) { }

  toEdit()
  {
    this.router.navigate(["main/edit-profile"]);
  }

  ngOnInit() {
    this.service.getEmployee().subscribe(response => {this.employee = response;
    console.log(this.employee);
    console.log(response);
    });
  }
}
