import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthModule } from './auth.module';

const routes: Routes = [
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    AuthModule
  ],
  exports: [RouterModule]
})
export class AuthRoutingModule {
}
