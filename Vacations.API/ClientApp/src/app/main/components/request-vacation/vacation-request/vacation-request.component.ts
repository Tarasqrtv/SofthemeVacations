import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-vacation-request',
  templateUrl: './vacation-request.component.html',
  styleUrls: ['./vacation-request.component.scss']
})
export class VacationRequestComponent implements OnInit {
  // startDate = new Date(1990, 0, 1);
  constructor(private location: Location) { }

  cancel() {
    this.location.back();
  }

  ngOnInit() {
  }

}
