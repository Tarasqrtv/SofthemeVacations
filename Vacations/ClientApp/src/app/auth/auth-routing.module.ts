import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthModule } from './auth.module';
import { AuthComponent } from './auth.component';

const routes: Routes = [
  { path: 'home', component: AuthComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    AuthModule
  ],
  exports: [RouterModule]
})
export class AuthRoutingModule {
}
