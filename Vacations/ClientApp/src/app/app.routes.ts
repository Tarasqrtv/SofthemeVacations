import { Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { ProfileComponent } from './profile/profile.component';

export const AppRoutes: Routes = [
    { path: 'auth', component: AuthComponent },
    { path: '', redirectTo: 'profile', pathMatch: 'full' },
    { path: '**', component: ProfileComponent }
];
