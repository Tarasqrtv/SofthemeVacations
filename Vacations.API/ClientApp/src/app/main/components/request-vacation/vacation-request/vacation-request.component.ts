import { Component, OnInit } from '@angular/core';
import { Location, getLocaleFirstDayOfWeek } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

import { EditService } from '../../../services/edit.service';
import { VacationService } from '../../../services/vacation.service';

import { Employee } from '../../edit-profile/models/employee.model';
import { Vacation } from '../../profile/my-vacations/vacation.model';

declare var require: any;

@Component({
  selector: 'app-vacation-request',
  templateUrl: './vacation-request.component.html',
  styleUrls: ['./vacation-request.component.scss']
})

export class VacationRequestComponent implements OnInit {

  
  employee: Employee = <Employee>{};
  vacation: Vacation = <Vacation>{};
  startDt: Date;
  endDt: Date;
  DateDiff = require('date-diff');

  constructor(private location: Location, private service: VacationService, private othService: EditService, private toast: ToastrService) { }

  cancel() {
    this.location.back();
  }

  ngOnInit() {
    const successfnEmployee = (response) => {
      this.employee = response;
      this.toast.success("", "");
      console.log(response);
      console.log(this.employee);
    };

    const errorfn = () => { };
    const completefn = () => { };

    this.othService.getEmployee().subscribe(successfnEmployee, errorfn, completefn);
  }

  ParseToDate(date) {
    console.log(date);
    var oneDate = new Date(date);
    return oneDate;
  }
  //(ParseToDate(vacation.EndVocationDate)-ParseToDate(vacation.StartVocationDate)) /1000/60/60/24
  DaysInVaac(frst, lst) {
    //let start = this.ParseToDate(frst);
    // let end = this.ParseToDate(lst);
    console.log("working!");
    let date = (frst - lst) / 1000 / 60 / 60 / 24;
    let dateLst = this.ParseToDate(date);
    console.log(dateLst);
    return dateLst;
  }

  DaysInVac(frst, lst) {
    console.log("working!");
    let start = this.ParseToDate(frst);
    let end = this.ParseToDate(lst);
    let diff = new this.DateDiff(start, end);
    console.log(diff.days());
    return diff.days();
  }

  Send() {
    console.log(this.employee);
    this.employee.EmployeeId = this.vacation.EmployeeId;
    this.service.SendVacation(this.vacation).subscribe(response => this.vacation = response);
    this.location.back();
    this.toast.success("You successfully send vacation request", "");
  }


}
