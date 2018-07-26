import {COMMA, ENTER} from '@angular/cdk/keycodes';
import {Component} from '@angular/core';
import {MatChipInputEvent} from '@angular/material';

export interface User {
  name: string;
}

@Component({
  selector: 'app-edit-team-profile',
  templateUrl: './edit-team-profile.component.html',
  styleUrls: ['./edit-team-profile.component.scss']
})

export class EditTeamProfileComponent{

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  users:  User[] = [
    {name: 'Andrew Doubt'},
    {name: 'Sergio Kapa'},
    {name: 'Sara Konor'},
  ];

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    // Add our user
    if ((value || '').trim()) {
      this.users.push({name: value.trim()});
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
