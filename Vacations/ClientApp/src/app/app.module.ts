import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ProfileModule } from './profile/profile.module';
import { AuthModule } from './auth/auth.module';
import { AppRoutes } from './app.routes';
import { MyFirstInterceptor } from './app.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { MainModule } from './main/main.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,

    RouterModule.forRoot(AppRoutes),

    MainModule,
    ProfileModule,
    AuthModule
  ],
  providers: [    {
    provide: HTTP_INTERCEPTORS,
    useClass: MyFirstInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
