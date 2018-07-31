import { Component, OnInit, Inject } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material';
import {MatDialogRef} from '@angular/material';

@Component({
  selector: 'app-calendar-popup-message',
  templateUrl: './calendar-popup-message.component.html',
  styleUrls: ['./calendar-popup-message.component.scss']
})
export class CalendarPopupMessageComponent implements OnInit {

  constructor(public thisDialogRef: MatDialogRef<CalendarPopupMessageComponent>, @Inject(MAT_DIALOG_DATA) public data: string) { }
  ngOnInit() {
  }
  onCloseCancel() {
    this.thisDialogRef.close('Cancel');
  }
}
