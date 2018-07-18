import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { ProfileComponent } from './profile.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { EmployeeProfileComponent } from './employee-profile/employee-profile.component';
import { GetEmployeeService } from './employee-profile/get-employee.service';
import { ProfileRoutes } from './profile.routes';

@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProfileComponent,
    EmployeeProfileComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,

    RouterModule.forChild(ProfileRoutes),
  ],
  providers: [GetEmployeeService]
})
export class ProfileModule { }
