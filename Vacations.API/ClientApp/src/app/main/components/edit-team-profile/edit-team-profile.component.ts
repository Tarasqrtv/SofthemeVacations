import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, OnInit } from '@angular/core';
import { MatChipInputEvent } from '@angular/material';

import { ProfileService } from '../../services/profile.service';

import { Profile } from '../profile/my-profile/profile.model';

export interface User {
  name: string;
}

@Component({
  selector: 'app-edit-team-profile',
  templateUrl: './edit-team-profile.component.html',
  styleUrls: ['./edit-team-profile.component.scss']
})

export class EditTeamProfileComponent implements OnInit {
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  
  users: User[] = [
    { name: 'Markiz de Saad' },
    { name: 'Harry Potter' },
    { name: 'Sara Konor' },
  ];

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




  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    // Add our user
    if ((value || '').trim()) {
      this.users.push({ name: value.trim() });
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  remove(user: User): void {
    const index = this.users.indexOf(user);

    if (index >= 0) {
      this.users.splice(index, 1);
    }
  }
}
