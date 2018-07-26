import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { LeftNavigationComponent } from './components/left-navigation/left-navigation.component';
import { MainComponent } from './main.component';

import { ProfileService } from './services/profile.service';
import { VacationService } from './services/vacation.service';

import { MyProfileComponent } from './components/profile/my-profile/my-profile.component';
import { TopNavigationComponent } from './components/top-navigation/top-navigation.component';
import { VacationRequestComponent } from './components/vacation-request/vacation-request.component';
import { MyVacationsComponent } from './components/profile/my-vacations/my-vacations.component';
import { BannerComponent } from './components/profile/banner/banner.component';
import { ProfileComponent } from './components/profile/profile.component';
import { MainRoutes } from './main.routes';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { MyFirstInterceptor } from '../app.service';
import { AddNewTeamComponent } from './components/add-new-team/add-new-team.component';
import { EditTeamProfileComponent } from './components/edit-team-profile/edit-team-profile.component';
import { ListOfVacationRequestsComponent } from './components/list-of-vacation-requests/list-of-vacation-requests.component';
import { ListOfTeamsComponent } from './components/list-of-teams/list-of-teams.component';
import { EditService } from './services/edit.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,

    RouterModule.forChild(MainRoutes),
  ],
  declarations: [
    BannerComponent,
    LeftNavigationComponent,
    MainComponent,
    MyProfileComponent,
    TopNavigationComponent,
    VacationRequestComponent,
    EditProfileComponent,
    MyVacationsComponent,
    ProfileComponent,
    AddNewTeamComponent,
    EditTeamProfileComponent,
    ListOfVacationRequestsComponent,
    ListOfTeamsComponent
  ],
  providers: [
    ProfileService,
    VacationService,
    EditService
  ]

})
export class MainModule { }
