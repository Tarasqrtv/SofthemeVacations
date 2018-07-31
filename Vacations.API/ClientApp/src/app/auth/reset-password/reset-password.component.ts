import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Info } from './info.model';
import { ToastrService } from 'ngx-toastr';
import { PasswordService } from '../password.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  
  code: string;
  id: string;
  userInfo: Info = <Info>{};

  constructor(private activateRoute: ActivatedRoute, 
      private toast: ToastrService, 
      private router: Router,
      private service: PasswordService ) {        
    this.id = this.activateRoute.snapshot.paramMap.get('id');
    this.code = this.activateRoute.snapshot.paramMap.get('code');
  }

  ngOnInit() {
  }
  
  Send() {
    this.userInfo.Code = this.code;
    this.userInfo.EmployeeId = this.id;
    console.log(this.userInfo);
    this.service.updateUserInfo(this.userInfo).subscribe(response => this.userInfo = response);;
    this.router.navigate(['/auth']);
    this.toast.success("You successfully edit profile", "");
    console.log(this.id);
  }
  
}
