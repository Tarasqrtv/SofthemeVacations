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

  user: { email: string, password: string };
  serviceResponse: { token: string, role: string };

  constructor(private service: AuthService) { }

  login() {
    this.service.post(requestUrl, this.user).subscribe(response => this.serviceResponse = response.json());
    localStorage.setItem("token", JSON.stringify(this.serviceResponse.token))
    localStorage.setItem("role", JSON.stringify(this.serviceResponse.role))
    console.log(this.user);
    console.log(this.serviceResponse.token);
    console.log(this.serviceResponse.role);
  }

  ngOnInit() {
    this.user = { email: '', password: '' };
    this.serviceResponse = { token: '', role: '' };
  }

  ngAfterViewInit() {
    this.inputEmail.nativeElement.focus();
  }

}
