import { Routes } from '@angular/router';

import { AuthComponent } from './auth.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { LoginComponent } from './login/login.component';

export const AuthRoutes: Routes = [
  { 
    path: 'auth',  component: AuthComponent,
    children: [     
      { path: '', component: LoginComponent},
      { path: 'reset-password', component: ResetPasswordComponent}
    ]
  }
];