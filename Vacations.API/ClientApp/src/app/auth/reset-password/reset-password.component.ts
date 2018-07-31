import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Info } from './info.model';
import { ToastrService } from 'ngx-toastr';
import { PasswordService } from '../password.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  
  userInfo: Info = <Info>{};
  private querySubscription: Subscription;

  constructor(private activateRoute: ActivatedRoute, 
      private toast: ToastrService, 
      private router: Router,
      private service: PasswordService ) {
      this.querySubscription = activateRoute.queryParams.subscribe(
          (queryParam: any) => {
              this.userInfo.EmployeeId = queryParam['id'];
              this.userInfo.Code = queryParam['code'];
          }
      );
  }

  ngOnInit() {
  }
  
  Send() {
    console.log(this.userInfo);
    this.service.updateUserInfo(this.userInfo).subscribe(response => this.userInfo = response);;
    this.router.navigate(['/auth']);
    this.toast.success("You successfully edit profile", "");
    console.log(this.userInfo);
  }
  
}
