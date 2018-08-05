import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../../services/profile.service';
import { Profile } from '../profile/my-profile/profile.model';

@Component({
  selector: 'app-add-new-team',
  templateUrl: './add-new-team.component.html',
  styleUrls: ['./add-new-team.component.scss']
})
export class AddNewTeamComponent implements OnInit {

  employees: Profile[] = [];
  noTeamEmpl: Profile[] = [];
  
  constructor(private service: ProfileService) { }

  ngOnInit() {
    this.service.getEmployees()
      .subscribe(response => {
        this.employees = response;
        for (let item of this.employees) {
          let i = 0;
          if (!item.TeamId) {
            this.noTeamEmpl[i] = item;
            i++;
          }
        }
    });
  }
}
