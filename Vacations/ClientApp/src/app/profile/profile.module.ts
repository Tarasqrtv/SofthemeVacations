import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { ProfileComponent } from './profile.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { EmployeeProfileComponent } from './employee-profile/employee-profile.component';

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
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent }
    ])
  ],
  providers: [],
  exports: [
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EmployeeProfileComponent],
    bootstrap: [ProfileComponent]
})
export class ProfileModule { }
