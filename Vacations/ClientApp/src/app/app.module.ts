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

const routes: Routes = [      
  { path: 'auth', component: AuthComponent},
  { path: '**', component: ProfileComponent}
];

const childRoutes: Routes = [      
  { path: 'profile', component: ProfileComponent, children: [      
    { path: 'home', component: HomeComponent },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent }
  ]}
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ProfileModule,
    AuthModule,
    RouterModule.forRoot(routes),
    RouterModule.forChild(childRoutes),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
