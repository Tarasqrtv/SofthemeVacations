import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/catch';
import { ToastrService } from 'ngx-toastr';

import { AuthService } from './auth.service';
import { User } from './auth.model';
import { environment } from '../../environments/environment';

const requestUrl = '/api/auth/token';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})

export class AuthComponent {

  constructor(private service: AuthService, private toaster: ToastrService, private router: Router) { }

  showInfo()
  {
    this.toaster.info("charles@gmail.com 1asdPass!","Login");
    localStorage.setItem("token", "");
    localStorage.setItem("role", "");
  }
}
