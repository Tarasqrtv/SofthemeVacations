import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthComponent } from './auth.component';
import { AuthService } from './auth.service';
import { LoginComponent } from './login/login.component';
import { SendResetComponent } from './send-reset/send-reset.component';
import { AuthRoutes } from './auth.routes';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

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
    SendResetComponent,
    ResetPasswordComponent
  ],
  providers: [AuthService],
  exports: [
    LoginComponent,
    SendResetComponent,
    ResetPasswordComponent
  ]
})
export class AuthModule { }
