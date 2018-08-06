import { Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { MainComponent } from './main/main.component';

import { AuthGuardService } from './auth/auth-guard.service';
import { MainRoutes } from './main/main.routes';
import { ProfileComponent } from './main/components/profile/profile.component';

export const AppRoutes: Routes = [
    { path: 'auth', component: AuthComponent },
    {
        path: '',
        component: MainComponent,
        canActivate: [AuthGuardService]
    },
    { path: '', redirectTo: '/profile', pathMatch: 'full' },
    { path: '**', redirectTo: '/profile'} //component: MainComponent  }
];
