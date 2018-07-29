import { Component, OnInit } from '@angular/core';

import { Vacation } from './vacation.model';
import { VacationService } from '../../../services/vacation.service';

@Component({
  selector: 'app-my-vacations',
  templateUrl: './my-vacations.component.html',
  styleUrls: ['./my-vacations.component.scss']
})
export class MyVacationsComponent implements OnInit {

  vacations: Vacation[];

  constructor(private service: VacationService) { }

  ngOnInit() {
    this.service.getVacations()
      .subscribe(response => this.vacations = response);
  }

  ParseToDate(date){
    let oneDate = new Date (date);
    return oneDate;
  }
}
