import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, HostListener } from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit, AfterViewInit {
  @ViewChild('inputEmail') inputEmail: ElementRef;

  user = {
    email: '',
    password: ''
  };

  constructor() { }

  ngOnInit() {
  }

  login() {
    console.log(this.user);
  }

  ngAfterViewInit() {
    this.inputEmail.nativeElement.focus();
  }

}
