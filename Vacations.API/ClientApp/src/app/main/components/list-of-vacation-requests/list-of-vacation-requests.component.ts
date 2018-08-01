import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { OpenVRPopupComponent } from '../open-vr-popup/open-vr-popup.component';

@Component({
  selector: 'app-list-of-vacation-requests',
  templateUrl: './list-of-vacation-requests.component.html',
  styleUrls: ['./list-of-vacation-requests.component.scss']
})
export class ListOfVacationRequestsComponent implements OnInit {

  constructor(public dialog: MatDialog) { }
  dialogResult = '';

  ngOnInit() {
  }

  openDialog() {
    const dialogRef = this.dialog.open(OpenVRPopupComponent, {
      width: '500px',
      data: 'This text is passed into the dialog!'
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog closed: ${result}`);
      this.dialogResult = result;
    });
  }
}
