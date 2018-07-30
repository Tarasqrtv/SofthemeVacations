import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

import { EditService } from '../../services/edit.service';

import { Team } from '../edit-profile/models/team.model';
import { JobTitle } from '../edit-profile/models/job-title.model';
import { EmployeeStatus } from '../edit-profile/models/employee-status.model';
import { Employee } from '../edit-profile/models/employee.model';

@Component({
  selector: 'app-add-new-employee',
  templateUrl: './add-new-employee.component.html',
  styleUrls: ['./add-new-employee.component.scss']
})
export class AddNewEmployeeComponent implements OnInit {

  employee: Employee = <Employee>{};
  teams: Team[] = [];
  jobTitles: JobTitle[] = [];
  employeeStatuses: EmployeeStatus[] = [];
  date = new Date;

  constructor(private location: Location, private service: EditService, private toast: ToastrService) { }

  cancel() {
    this.location.back();
  }

  ngOnInit() {
      const successfnTeams = (response) => {
      this.teams = response;
      this.toast.success("", "");
      console.log(response);
      console.log(this.teams);
    };
    const successfnJobTitles = (response) => {
      this.jobTitles = response;
      this.toast.success("", "");
      console.log(response);
      console.log(this.jobTitles);
    };
    const successfnEmployeeStatus = (response) => {
      this.employeeStatuses = response;
      this.toast.success("", "");
      console.log(response);
      console.log(this.employeeStatuses);
    };

    const errorfn = () => { };
    const completefn = () => { };

    this.service.getTeam().subscribe(successfnTeams, errorfn, completefn);
    this.service.getJobTitle().subscribe(successfnJobTitles, errorfn, completefn);
    this.service.getEmployeeStatus().subscribe(successfnEmployeeStatus, errorfn, completefn);
  }

  Save() {
    console.log(this.employee);
    this.service.addEmployee(this.employee).subscribe(response => this.employee = response);;
    this.location.back();
    this.toast.success("You successfully added new profile", "");
    console.log(this.employeeStatuses);
  }
}