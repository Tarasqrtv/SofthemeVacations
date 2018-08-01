import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { Mail } from './mail.model';
import { PasswordService } from '../password.service';



@Component({
  selector: 'app-send-reset',
  templateUrl: './send-reset.component.html',
  styleUrls: ['./send-reset.component.scss']
})
export class SendResetComponent implements OnInit {

  userMail: Mail = <Mail>{};

  constructor(private toast: ToastrService, private router: Router, private service: PasswordService) { }

  ngOnInit() {
  }

  Send() {
    console.log(this.userMail);
    this.service.sendEmail(this.userMail).subscribe(response => this.userMail = response);;
    this.router.navigate(['/auth']);
    this.toast.success("You successfully edit profile", "");
    console.log(this.userMail.email);
  }
}