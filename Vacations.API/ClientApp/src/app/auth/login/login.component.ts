import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/catch';
import { User } from '../auth.model';
import { AuthService } from '../auth.service';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../environments/environment.prod';

const requestUrl = '/api/auth/token';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit, AfterViewInit {
  @ViewChild('inputEmail') inputEmail: ElementRef;

  user: { email: string, password: string };
  serviceResponse: User;

  constructor(private service: AuthService, private toaster: ToastrService, private router: Router) { }

  login() {
    localStorage.setItem("token", "");
    localStorage.setItem("role", "");
    let requestUrl = environment.baseUrl + '/auth/token';
    this.service.get(requestUrl, this.user).subscribe(
      response => {
      this.serviceResponse = response;
      localStorage.setItem("token", this.serviceResponse.Token);
      localStorage.setItem("role", JSON.stringify(this.serviceResponse.Role));
      this.router.navigate(["/main"])
    }
  )
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
    localStorage.setItem("token", "");
    localStorage.setItem("role", "");
  }
}
