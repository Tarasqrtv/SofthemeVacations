import { Routes } from '@angular/router';

import { AuthComponent } from './auth.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

export const MainRoutes: Routes = [
  {
    path: 'auth', component: AuthComponent,
    children: [     
      {path: 'reset-oassword', component: ResetPasswordComponent}
    ]
  }
];
