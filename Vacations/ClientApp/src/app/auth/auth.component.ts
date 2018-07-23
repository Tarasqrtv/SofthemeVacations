import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, HostListener } from '@angular/core';

import { AuthService } from './auth.service';
import { User } from './auth.model';
import { ToastrService } from '../../../node_modules/ngx-toastr';

const requestUrl = '/api/auth/token';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})

export class AuthComponent implements OnInit, AfterViewInit {
  @ViewChild('inputEmail') inputEmail: ElementRef;

  user: { email: string, password: string };
  serviceResponse: User;

  constructor(private service: AuthService, private toaster: ToastrService) { }

  login() {
    this.service.get(requestUrl, this.user).subscribe(response => {
      this.serviceResponse = response;
      console.log(this.serviceResponse.Token);
      console.log(this.serviceResponse.Role);
      console.log(localStorage.getItem("token"));
      console.log(localStorage.getItem("role"));
      localStorage.setItem("token", this.serviceResponse.Token);
      localStorage.setItem("role", JSON.stringify(this.serviceResponse.Role));
    });
  }

  ngOnInit() {
    this.user = { email: '', password: '' };
  }

  ngAfterViewInit() {
    this.inputEmail.nativeElement.focus();
  }
  showInfo()
  {
    this.toaster.info("charles@gmail.com pass","Login");
  }
}
