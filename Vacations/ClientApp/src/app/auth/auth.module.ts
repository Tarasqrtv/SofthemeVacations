import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthComponent } from './auth.component';
import { AuthService } from './auth.service';
import { LoginComponent } from './login/login.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  declarations: [
    LoginComponent,
    AuthComponent
  ],
  providers: [AuthService],
  exports: [
    LoginComponent
  ]
})
export class AuthModule { }
