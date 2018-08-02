import { Component, OnInit, Inject } from '@angular/core';
//import { MAT_DIALOG_DATA } from '@angular/material';
//import { MatDialogRef } from '@angular/material';

import { Vacation } from '../profile/my-vacations/vacation.model';
import { VacationService } from '../../services/vacation.service';
import { EditService } from '../../services/edit.service';
import { Employee } from '../edit-profile/models/employee.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-open-vr-popup',
  templateUrl: './open-vr-popup.component.html',
  styleUrls: ['./open-vr-popup.component.scss']
})
export class OpenVRPopupComponent implements OnInit {

  vacations: Vacation[] = [];
  emplVacation: Vacation = <Vacation>{};
  employee: Employee = <Employee>{};

  constructor(private vacService: VacationService,
    private emplService: EditService,
    public thisDialogRef: MatDialogRef<OpenVRPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string) { }

  ngOnInit() {
    console.log(this.data);
    const successfnEmployee = (response) => {
      this.employee = response;
      console.log(this.employee);
    };

    const errorfn = () => { };
    const completefn = () => { };

    this.vacService.getVacation(this.data).subscribe(response => {
      this.emplVacation = response;
      console.log(response);
      this.emplService.getEmployeeId(this.emplVacation.EmployeeId).subscribe(successfnEmployee, errorfn, completefn);
    });   
  }

  parseDate(dateString: any): Date {
    if (dateString) {
      return new Date(dateString);
    } else {
      return null;
    }
  }

  DaysInVac(frst, lst) {
    let date = (lst - frst) / 1000 / 60 / 60 / 24;
    return date;
  }

  onCloseCancel() {

    this.thisDialogRef.close('Cancel');
  }

  onCloseConfirm() {
    this.thisDialogRef.close('Confirm');
  }

  // Save() {
  //   const successfnEmplUpdates = (response) => {
  //     this.employee = response;
  //   };
  //   const LocBack = () => this.location.back();
  //   console.log(this.employee);
  //   console.log(this.fileToUpload);
  //   if (this.fileToUpload != null) {
  //     this.uploadFileToActivity();
  //   }
  //   this.service.updateEmployee(this.employee).subscribe(successfnEmplUpdates, LocBack);;
    
  //   this.toast.success("You successfully edit profile", "");
  //   console.log(this.employeeStatuses);
  // }

}
