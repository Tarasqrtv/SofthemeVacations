import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { ProfileComponent } from './profile/profile.component';
import { ProfileModule } from './profile/profile.module';
import { AuthModule } from './auth/auth.module';
import { HomeComponent } from './profile/home/home.component';
import { CounterComponent } from './profile/counter/counter.component';
import { FetchDataComponent } from './profile/fetch-data/fetch-data.component';
import { EmployeeProfileComponent } from './profile/employee-profile/employee-profile.component';

const routes: Routes = [      
  { path: 'auth', component: AuthComponent},
  { path: '**', component: ProfileComponent}
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,

    RouterModule.forRoot(routes),

    ProfileModule,
    AuthModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
