import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-request-vacation',
  templateUrl: './request-vacation.component.html',
  styleUrls: ['./request-vacation.component.scss']
})
export class RequestVacationComponent implements OnInit {

  constructor(private location: Location) { }

  cancel() {
    this.location.back();
   }


  ngOnInit() {
  }

}
