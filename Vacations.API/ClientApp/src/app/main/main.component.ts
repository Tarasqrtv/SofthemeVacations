import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  IsShowLeftNav: boolean;

  constructor() { }

  ngOnInit() {
    this.IsShowLeftNav = false;
    if(localStorage.getItem('role') != 'Employee')
    {
      this.IsShowLeftNav = true;
    }
  }
}
