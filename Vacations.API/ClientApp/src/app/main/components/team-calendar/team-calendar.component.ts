import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import {MatDialog} from '@angular/material';
import { CalendarPopupMessageComponent } from '../calendar-popup-message/calendar-popup-message.component';

@Component({
  selector: 'app-team-calendar',
  templateUrl: './team-calendar.component.html',
  styleUrls: ['./team-calendar.component.scss']
})

export class TeamCalendarComponent implements AfterViewInit, OnInit {
  constructor(public dialog: MatDialog) {}

  dialogResult = '';
  @ViewChild('calendar') calendar: ElementRef;

  currentDate = new Date();
  vacationsList: any[];

  ngOnInit() {
    this.vacationsList = this.getEmplVacations();
  }

  openDialog() {
    const dialogRef = this.dialog.open(CalendarPopupMessageComponent, {
      width: '500px',
      data: 'This text is passed into the dialog!'
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog closed: ${result}`);
      this.dialogResult = result;
    });
  }

  ngAfterViewInit() {
    this.renderCalendar();
  }

  btnNextClick() {
    this.currentDate = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() + 1, 1);

    this.renderCalendar();
  }

  btnPrevClick() {
    this.currentDate = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() - 1, 1);

    this.renderCalendar();
  }

  private getStartDateForLoop(): Date {
    const currentFirstDateOfMonth = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), 1);
    const currentFirstDayOfMonth = currentFirstDateOfMonth.getDay();


    return new Date(
      this.currentDate.getFullYear(),
      this.currentDate.getMonth(),
      1 - 6 + currentFirstDayOfMonth
    );
  }

  private getEndDateForLoop(): Date {
    const nextMonthFirstDate = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() + 1, 1);
    const nextMonthFirstDayOfWeek = nextMonthFirstDate.getDay();

    return new Date(
      this.currentDate.getFullYear(),
      this.currentDate.getMonth() + 1,
      1 + nextMonthFirstDayOfWeek + 1
    );
  }

  private renderCalendar() {
    const loopDate = this.getStartDateForLoop();

    const endDate = this.getEndDateForLoop();
    let weekResetter = 0;
    let weekRow: HTMLTableRowElement;
    const calendarTable = <HTMLTableElement>this.calendar.nativeElement;
    calendarTable.tBodies[0].innerText = '';

    do {
      if (weekResetter % 7 === 0) {
        weekRow = calendarTable.insertRow();
      }

      const cell = weekRow.insertCell();
      cell.innerText = loopDate.getDate().toString();

      cell.classList.add('date');

      if (loopDate.getMonth() === this.currentDate.getMonth()) {
        cell.classList.add('selected-month-date');
      } else if (loopDate.getMonth() < this.currentDate.getMonth()) {
        cell.classList.add('prev-month-date');
      } else {
        cell.classList.add('next-month-date');
      }

      weekResetter++;
      loopDate.setDate(loopDate.getDate() + 1);
    } while (!(loopDate.getMonth() === endDate.getMonth()
      && loopDate.getDate() > endDate.getDate()));
  }

  private getEmplVacations() {
    const emplVacations = [
      { id: 23, name: 'Vitaliy Khmelko', startDate: 1530565200000, endDate: '1531602000000' },
      { id: 23, name: 'Andrey', startDate: 1530565200000, endDate: '1531602000000' },
      { id: 23, name: 'Ivan', startDate: 1530565200000, endDate: '1531602000000' }

    ];

    return emplVacations;
  }

}
