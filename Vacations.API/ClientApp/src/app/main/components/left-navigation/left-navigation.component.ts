import { Component, OnInit } from '@angular/core';

import { VacationService } from '../../services/vacation.service';

import { VacRequest } from '../list-of-vacation-requests/vacation-request.model';

@Component({
  selector: 'app-left-navigation',
  templateUrl: './left-navigation.component.html',
  styleUrls: ['./left-navigation.component.scss']
})
export class LeftNavigationComponent implements OnInit {
  
  IsShow: boolean;

  vacations: VacRequest[];
  vacCount: number;
  constructor(private service: VacationService) { }

  ngOnInit() {
    this.IsShow = false;
    if(localStorage.getItem('role') === "Admin")
    {
      this.IsShow = true;
    }
    this.service.getVacationRequests().subscribe(response => {
      this.vacations = response;
      this.vacCount = this.vacations.length;
      console.log("left");
    });
  }
}
