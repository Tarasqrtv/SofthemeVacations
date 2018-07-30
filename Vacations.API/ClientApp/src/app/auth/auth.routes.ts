import { Routes } from '@angular/router';

import { AuthComponent } from './auth.component';
import { SendResetComponent } from './send-reset/send-reset.component';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

export const AuthRoutes: Routes = [
  {
    path: 'auth', component: AuthComponent,
    children: [
      { path: '', component: LoginComponent },
      { path: 'send-reset', component: SendResetComponent },
      { path: 'reset-password', component: ResetPasswordComponent }
    ]
  }
];
