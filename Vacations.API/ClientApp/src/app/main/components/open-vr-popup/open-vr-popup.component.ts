import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';

import { ToastrService } from 'ngx-toastr';
import { VacationService } from '../../services/vacation.service';
import { EditService } from '../../services/edit.service';

import { Employee } from '../edit-profile/models/employee.model';
import { VacRequest } from '../list-of-vacation-requests/vacation-request.model';
import { Statuses } from './vacation-statuses.model';



@Component({
  selector: 'app-open-vr-popup',
  templateUrl: './open-vr-popup.component.html',
  styleUrls: ['./open-vr-popup.component.scss']
})
export class OpenVRPopupComponent implements OnInit {

  emplVacation: VacRequest = <VacRequest>{};
  employee: Employee = <Employee>{};
  vacStatuses: Statuses[] = [];
  dateDiff: any = 'XX';
  imgUrl: string

  constructor(private vacService: VacationService,
    private emplService: EditService,
    private toastr: ToastrService,
    public thisDialogRef: MatDialogRef<OpenVRPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string) { }

  ngOnInit() {
    this.imgUrl = '../../../../assets/user-profile-icon.svg';
    console.log(this.data);
    const successfnEmployee = (response) => {
      this.employee = response;
      console.log(this.employee);
      if(this.employee.ImgUrl !== null)
      {
        this.imgUrl = this.employee.ImgUrl;
      }
    };

    const errorfn = () => { };
    const completefn = () => { };

    this.vacService.getVacation(this.data).subscribe(response => {
      this.emplVacation = response;
      console.log(response);
      this.calculateDate();
      this.emplService.getEmployeeId(this.emplVacation.EmployeeId).subscribe(successfnEmployee, errorfn, completefn);
      this.balanceChecking();
    }); 

    this.vacService.getVacationStatuses().subscribe(response => {
      this.vacStatuses = response;
      console.log(response);
    })
  }

  balanceChecking(){
    if (this.emplVacation.EmployeeBalance < this.calculateDate()) {
      this.toastr.warning("Request number less than amount", "");
    } 
  }

  calculateDate() {
   return this.DaysInVac(
      this.parseDate(this.emplVacation.StartVocationDate),
      this.parseDate(this.emplVacation.EndVocationDate));
  }

  parseDate(dateString: any): Date {
    if (dateString) {
      return new Date(dateString);
    } else {
      return null;
    }
  }

  DaysInVac(frst, lst) {
    return this.dateDiff = (lst - frst) / 1000 / 60 / 60 / 24;
  }

  onCloseConfirm() {
    this.thisDialogRef.close('Confirm');
  }

  onCloseCancel() {
    console.log(this.emplVacation);
    this.thisDialogRef.close('Cancel');
    this.vacService.SendVacationRequest(this.emplVacation).subscribe(response => {
      this.toastr.success("You successfully send answer on vacation request", "");
    });
  }
}
