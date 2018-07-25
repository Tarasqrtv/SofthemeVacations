import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { EditService } from '../../services/edit.service';
import { Profile } from '../profile/my-profile/profile.model';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {
constructor(private location: Location) { }

  cancel() {
    this.location.back();
  }

  ngOnInit() {
  }
}

// export class EditProfileComponent implements OnInit {
//   title = 'profile';
//   employee: Employee;

//   constructor(private service: EditService) { }

//   ngOnInit() { }
//   //save(): void {
//   //  this.service.updateEmployee(this.employee)
//   //    .subscribe(() => this.location.back();;
//   //}

// }
