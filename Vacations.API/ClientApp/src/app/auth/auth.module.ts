import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { JwtModule, JwtModuleOptions } from '@auth0/angular-jwt';

import { AuthComponent } from './auth.component';
import { AuthService } from './auth.service';
import { LoginComponent } from './login/login.component';
import { SendResetComponent } from './send-reset/send-reset.component';
import { AuthRoutes } from './auth.routes';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { AuthGuardService } from './auth.guard';

const JWT_Module_Options: JwtModuleOptions = {
  config: {
      tokenGetter: () => {return localStorage.getItem('access_token');} ,
      whitelistedDomains: ['localhost:4200']
  }
};

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    
    JwtModule.forRoot(JWT_Module_Options),
    RouterModule.forChild(AuthRoutes)
  ],
  declarations: [
    LoginComponent,
    AuthComponent,
    SendResetComponent,
    ResetPasswordComponent
  ],
  providers: [AuthService, AuthGuardService],
  exports: [
    LoginComponent,
    SendResetComponent,
    ResetPasswordComponent
  ]
})
export class AuthModule { }
