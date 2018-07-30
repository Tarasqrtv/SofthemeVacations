import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthComponent } from './auth.component';
import { AuthService } from './auth.service';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { AuthRoutes } from './auth.routes';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    
    RouterModule.forChild(AuthRoutes)
  ],
  declarations: [
    LoginComponent,
    AuthComponent,
    ResetPasswordComponent
  ],
  providers: [AuthService],
  exports: [
    LoginComponent,
    ResetPasswordComponent
  ]
})
export class AuthModule { }
