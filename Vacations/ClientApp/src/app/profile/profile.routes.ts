import { Routes } from '@angular/router';
import { ProfileComponent } from './profile.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { EmployeeProfileComponent } from './employee-profile/employee-profile.component';

export const ProfileRoutes: Routes = [
    {
        path: 'profile',
        component: ProfileComponent,
        children: [
            { path: '', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'employee-profile', component: EmployeeProfileComponent }
        ]
    }
];
