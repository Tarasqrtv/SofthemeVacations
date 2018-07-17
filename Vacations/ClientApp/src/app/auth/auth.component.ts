import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, HostListener } from '@angular/core';

import { AuthService } from './auth.service';

const requestUrl = '/api/auth/token';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})

export class AuthComponent implements OnInit, AfterViewInit {
  @ViewChild('inputEmail') inputEmail: ElementRef;

  token: string
  user: { email: string, password: string};

  constructor(private service: AuthService) { }

  login()
  {
    this.service.post(requestUrl, this.user).subscribe(response => this.token = response);
    console.log(this.user);
    console.log(this.token);
  }

  ngOnInit() {
    this.token = '';
    this.user = { email: '', password: '' };
  }

  ngAfterViewInit() {
    this.inputEmail.nativeElement.focus();
  }

}
