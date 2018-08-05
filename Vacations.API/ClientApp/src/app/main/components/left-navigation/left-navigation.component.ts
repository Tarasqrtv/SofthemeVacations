import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-left-navigation',
  templateUrl: './left-navigation.component.html',
  styleUrls: ['./left-navigation.component.scss']
})
export class LeftNavigationComponent implements OnInit {
  
  IsShow: boolean;

  constructor() { }

  ngOnInit() {
    this.IsShow = false;
    if(localStorage.getItem('role') === "Admin")
    {
      this.IsShow = true;
    }
  }

}
