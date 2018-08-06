import { Injectable } from '@angular/core';
import { 
  Router,
  CanActivate,
  ActivatedRouteSnapshot
} from '@angular/router';
import { AuthService } from './auth.service';
import decode from 'jwt-decode';

@Injectable()
export class RoleGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}
  canActivate(route: ActivatedRouteSnapshot): boolean {
    // this will be passed from the route config
    // on the data property
    const expectedAdminRole = route.data.expectedAdminRole;
    const expectedTeamLeadRole = route.data.expectedTeamLeadRole;
    const role = localStorage.getItem('role');
    // decode the token to get its payload
    //const tokenPayload = decode(token);
    if (
      !this.auth.isAuthenticated() 
    ) {
      console.log("Role guard auth")
      this.router.navigate(['auth']);
      return false;
    }
    if (
      role !== expectedAdminRole && role !== expectedTeamLeadRole
    ) {
      console.log(localStorage.getItem('role'))
      console.log("Role guard main")
      this.router.navigate(['main']);
      return false;
    }
    return true;
  }
}
      