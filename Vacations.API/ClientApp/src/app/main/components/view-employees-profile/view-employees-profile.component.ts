import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-employees-profile',
  templateUrl: './view-employees-profile.component.html',
  styleUrls: ['./view-employees-profile.component.scss']
})
export class ViewEmployeesProfileComponent implements OnInit {

  constructor(private router: Router) { }
  toEdit() {
    this.router.navigate(['main/edit-profile']);
  }
  ngOnInit() {
  }
  onCloseCancel() {

  }

}
