import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { OpenVRPopupComponent } from '../open-vr-popup/open-vr-popup.component';

import { Vacation } from '../profile/my-vacations/vacation.model';
import { VacationService } from '../../services/vacation.service';
import { VacRequest } from './vacation-request.model';

@Component({
  selector: 'app-list-of-vacation-requests',
  templateUrl: './list-of-vacation-requests.component.html',
  styleUrls: ['./list-of-vacation-requests.component.scss']
})
export class ListOfVacationRequestsComponent implements OnInit {

  vacations: VacRequest[];
  
  constructor(public dialog: MatDialog, private service: VacationService) { }
  dialogResult = '';

  ngOnInit() {
    this.service.getVacationRequests().subscribe(response => {
      this.vacations = response;
      console.log(this.vacations);
      console.log(response);
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

  openDialog(vacId: string) {
    console.log(vacId);
    const dialogRef = this.dialog.open(OpenVRPopupComponent, {
      width: '500px',
      data: vacId
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog closed: ${result}`);
      this.dialogResult = result;
    });

  }
}
