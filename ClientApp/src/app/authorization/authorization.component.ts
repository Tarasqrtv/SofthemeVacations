import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css']
})
export class AuthorizationComponent implements OnInit
{
  logoUrl: string;
  loginIconUrl: string;
  passIconUrl: string;
  ngOnInit()
  {
    this.logoUrl = 'assets/fontsicons/softheme.svg';
    this.loginIconUrl = 'assets/fontsicons/user_icon.svg';
    this.passIconUrl = 'assets/fontsicons/password_icon.svg';
  }
}
