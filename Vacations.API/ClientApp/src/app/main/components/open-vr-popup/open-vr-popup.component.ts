import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-open-vr-popup',
  templateUrl: './open-vr-popup.component.html',
  styleUrls: ['./open-vr-popup.component.scss']
})
export class OpenVRPopupComponent implements OnInit {

  constructor(public thisDialogRef: MatDialogRef<OpenVRPopupComponent>, @Inject(MAT_DIALOG_DATA) public data: string) { }
  ngOnInit() {
  }
  onCloseCancel() {
    this.thisDialogRef.close('Cancel');
  }
  onCloseConfirm() {
    this.thisDialogRef.close('Confirm');
  }

}
