import { Component, OnInit } from '@angular/core';
import { Location, getLocaleFirstDayOfWeek } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

import { EditService } from '../../../services/edit.service';
import { VacationService } from '../../../services/vacation.service';

import { Employee } from '../../edit-profile/models/employee.model';
import { Vacation } from '../../profile/my-vacations/vacation.model';

@Component({
  selector: 'app-vacation-request',
  templateUrl: './vacation-request.component.html',
  styleUrls: ['./vacation-request.component.scss']
})

export class VacationRequestComponent implements OnInit {


  employee: Employee = <Employee>{};
  vacation: Vacation = <Vacation>{};
 

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

  parseDate(dateString: any): Date {
    console.log("parsing DATE");
    console.log(dateString);
    if (dateString) {
      return new Date(dateString);
    } else {
      return null;
    }
  }

  DaysInVac(frst, lst) {
    console.log("Datediff!");
    let date = (lst - frst) / 1000 / 60 / 60 / 24;
    return date;
  }

  Send() {
    console.log(this.employee);
    this.employee.EmployeeId = this.vacation.EmployeeId;
    this.service.SendVacation(this.vacation).subscribe(response => this.vacation = response);
    this.location.back();
    this.toast.success("You successfully send vacation request", "");
  }
}
