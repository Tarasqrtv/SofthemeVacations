import { Routes } from '@angular/router';

import { MainComponent } from './main.component';
import { ProfileComponent } from './components/profile/profile.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';

export const MainRoutes: Routes = [
    {
        path: 'main',  component: MainComponent,
        children: [
            { path: '', component: ProfileComponent },
            { path: 'profile', component: ProfileComponent },     
            { path: 'edit-profile', component: EditProfileComponent }        
        ]
    }
];
