import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

import { EditService } from '../../services/edit.service';
import { Employee } from './models/employee.model';
import { Team } from './models/team.model';
import { JobTitle } from './models/job-title.model';
import { EmployeeStatus } from './models/employee-status.model';

import { EmployeeRole } from './models/employee-roles.model';
import { ImageService } from '../../services/image.service';
import { environment } from '../../../../environments/environment';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {
  id: string;
  private subscription: Subscription;

  employee: Employee = <Employee>{};
  teams: Team[] = [];
  jobTitles: JobTitle[] = [];
  employeeStatuses: EmployeeStatus[] = [];
  employeeRoles: EmployeeRole[] = [];
  date = new Date;

  constructor(private imgUploadService: ImageService,
    private location: Location,
    private service: EditService,
    private toast: ToastrService,
    private activateRoute: ActivatedRoute) {
      this.id = this.activateRoute.snapshot.paramMap.get('id');
  }


  fileToUpload: File = null;
  imgUrl: string;

  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }

  uploadFileToActivity() {
    this.imgUploadService.postFile(environment.baseUrl + "/images/upload", this.fileToUpload).subscribe(data => {
      this.toast.success("File uploaded!", "Success")
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.location.back();
  }

  ngOnInit() {
    const successfnEmployee = (response) => {
      this.employee = response;
      console.log(response);
      console.log(this.employee);
    };
    const successfnTeams = (response) => {
      this.teams = response;
      console.log(response);
      console.log(this.teams);
    };
    const successfnJobTitles = (response) => {
      this.jobTitles = response;
      console.log(response);
      console.log(this.jobTitles);
    };
    const successfnEmployeeStatus = (response) => {
      this.employeeStatuses = response;
      console.log(response);
      console.log(this.employeeStatuses);
    };
    const successfnEmployeeRole = (response) => {
      this.employeeRoles = response;
      this.toast.success("", "");
      console.log(response);
      console.log(this.employeeRoles);
    };

    const errorfn = () => { };
    const completefn = () => { };

    this.service.getEmployeeId(this.id).subscribe(successfnEmployee, errorfn, completefn);
    this.service.getTeam().subscribe(successfnTeams, errorfn, completefn);
    this.service.getJobTitle().subscribe(successfnJobTitles, errorfn, completefn);
    this.service.getEmployeeStatus().subscribe(successfnEmployeeStatus, errorfn, completefn);
    this.service.getEmployeeRole().subscribe(successfnEmployeeRole, errorfn, completefn);

    this.imgUploadService.getImgUrl().subscribe(
      response => { this.imgUrl = response; console.log(response); console.log(this.imgUrl); },
      () => this.imgUrl = "default");
  }

  Save() {
    console.log(this.employee);
    this.service.updateEmployee(this.employee).subscribe(response => this.employee = response);;
    this.location.back();
    this.toast.success("You successfully edit profile", "");
    console.log(this.employeeStatuses);
  }
}
