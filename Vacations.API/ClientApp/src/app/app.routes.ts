import { Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { MainComponent } from './main/main.component';

import { AuthGuardService } from './auth/auth-guard.service';

export const AppRoutes: Routes = [
    { path: 'auth', component: AuthComponent },
    { path: '', redirectTo: 'main', pathMatch: 'full',
        canActivate: [AuthGuardService]  },
    { path: 'main', component: MainComponent,
        canActivate: [AuthGuardService] },
    { path: '**', component: MainComponent,
        canActivate: [AuthGuardService]  }
];
