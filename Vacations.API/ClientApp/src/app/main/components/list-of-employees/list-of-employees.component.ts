import { Component, OnInit } from '@angular/core';
import { Profile } from '../profile/my-profile/profile.model';
import { ProfileService } from '../../services/profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-of-employees',
  templateUrl: './list-of-employees.component.html',
  styleUrls: ['./list-of-employees.component.scss']
})
export class ListOfEmployeesComponent implements OnInit {
  employees: Profile[] = [];
  
  constructor(private service: ProfileService, private router: Router) { }

  toWiew(employee: Profile) {
    this.router.navigate(['../profile', employee.EmployeeId]);
  }

  toEdit(employee: Profile) {
    this.router.navigate(['../edit-profile', employee.EmployeeId]);
  }

  ngOnInit() {
    this.service.getEmployees()
      .subscribe(response => this.employees = response);
  }
}
