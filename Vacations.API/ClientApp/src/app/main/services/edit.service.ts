import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Profile } from '../components/profile/my-profile/profile.model';
import { environment } from '../../../environments/environment';
import { Employee } from '../components/edit-profile/models/employee.model';
import { JobTitle } from '../components/edit-profile/models/job-title.model';
import { EmployeeStatus } from '../components/edit-profile/models/employee-status.model';
import { Team } from '../components/edit-profile/models/team.model';

@Injectable()
export class EditService {
    constructor (private http: HttpClient) { }

    updateEmployee(employee: Employee): Observable<Employee> {
        let requestUrl = environment.baseUrl + '/employees';
        const data = JSON.stringify(employee);
        return this.http.put(requestUrl, data).map(() => employee);
    }

    getProfile(): Observable<Profile> {
        let requestUrl = environment.baseUrl + '/profile';
        return this.http.get<Profile>(`${requestUrl}`);
    }

    getJobTitle(): Observable<JobTitle[]> {
        let requestUrl = environment.baseUrl + '/jobtitles';
        return this.http.get<JobTitle[]>(`${requestUrl}`);
    }

    getEmployeeStatus(): Observable<EmployeeStatus[]> {
        let requestUrl = environment.baseUrl + '/employeestatus';
        return this.http.get<EmployeeStatus[]>(`${requestUrl}`);
    }

    getTeam(): Observable<Team[]> {
        let requestUrl = environment.baseUrl + '/teams';
        return this.http.get<Team[]>(`${requestUrl}`);
    }
}

