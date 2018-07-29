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
  toEdit() {
    this.router.navigate(['main/edit-profile']);
  }

  ngOnInit() {
    this.service.getProfiles().subscribe(response => {
      this.employees = response;
      console.log(this.employees);
      console.log(response);
    });
  }

}
