import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  id: string;

  private code: number;
  private subscription: Subscription;
  constructor(private activateRoute: ActivatedRoute) {
    this.id = this.activateRoute.snapshot.paramMap.get('id');
  }

  ngOnInit() {
  }

  
}
