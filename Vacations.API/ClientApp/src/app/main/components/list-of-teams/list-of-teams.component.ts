import { Component, OnInit } from '@angular/core';
import { Team } from '../edit-profile/models/team.model';
import { TeamService } from '../../services/team.service';

@Component({
  selector: 'app-list-of-teams',
  templateUrl: './list-of-teams.component.html',
  styleUrls: ['./list-of-teams.component.scss']
})
export class ListOfTeamsComponent implements OnInit {
  teams: Team[] =[];

  constructor(private teamService: TeamService) { }

  ngOnInit() {
    this.teamService.getTeams()
      .subscribe(response => {
        this.teams = response;
        console.log(this.teams);
      });
  }
}
