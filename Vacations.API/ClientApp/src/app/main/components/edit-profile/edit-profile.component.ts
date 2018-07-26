import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { EditService } from '../../services/edit.service';
import { Profile } from '../profile/my-profile/profile.model';
import { Employee } from './models/employee.model';
import { Team } from './models/team.model';
import { JobTitle } from './models/job-title.model';
import { EmployeeStatus } from './models/employee-status.model';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

  profile: Profile = <Profile>{};
  employee: Employee = <Employee>{};
  teams: Team[] = <Team[]>{};
  jobTitles: JobTitle[] = <JobTitle[]>{};
  employeeStatuses: EmployeeStatus[] = <EmployeeStatus[]>{};
  
constructor(private location: Location, private service: EditService) { }

  cancel() {
    this.location.back();
  }

  ngOnInit() {
    this.service.getProfile().subscribe(response => {this.profile = response;
      console.log(this.employee);
      console.log(response);
      });
  }
}

// export class EditProfileComponent implements OnInit {
//   title = 'profile';
//   employee: Employee;

//   constructor(private service: EditService) { }

//   ngOnInit() { }
//   //save(): void {
//   //  this.service.updateEmployee(this.employee)
//   //    .subscribe(() => this.location.back();;
//   //}

// }
