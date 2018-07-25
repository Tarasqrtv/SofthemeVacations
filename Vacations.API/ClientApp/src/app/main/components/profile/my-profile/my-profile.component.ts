import { Component, OnInit, Input } from '@angular/core';
import { Profile } from './profile.model';
import { Router } from '@angular/router';
import { ProfileService } from '../../../services/profile.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})

export class MyProfileComponent implements OnInit {
  title = 'profile';
  
  employee: Profile = <Profile>{};
  
  constructor(private service: ProfileService, private router: Router) { }

  toEdit()
  {
    this.router.navigate(["main/edit-profile"]);
  }

  ngOnInit() {
    this.service.getProfile().subscribe(response => {this.employee = response;
    console.log(this.employee);
    console.log(response);
    });
  }
}
