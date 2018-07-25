import { Component, OnInit } from '@angular/core';

import { Profile } from '../my-profile/profile.model';
import { ProfileService } from '../../../services/profile.service';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.scss']
})
export class BannerComponent implements OnInit {

  employee: Profile = <Profile>{};
  
  constructor(private service: ProfileService) { }

  ngOnInit() {
    this.service.getProfile().subscribe(response => this.employee = response);
  }

}
