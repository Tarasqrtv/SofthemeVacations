import { Component, OnInit } from '@angular/core';

import { VacationService } from '../../services/vacation.service';
import { Vacation } from './vacation.model';

@Component({
  selector: 'app-vacation',
  templateUrl: './vacation.component.html',
  styleUrls: ['./vacation.component.css']
})
export class VacationComponent implements OnInit {
  vacations: Vacation[];

  constructor(private service: VacationService) { }

  ngOnInit() {
    this.service.getVacations()
      .subscribe(response => this.vacations = response);
  }

}
