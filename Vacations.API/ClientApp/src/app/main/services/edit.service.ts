import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Subscription } from 'rxjs';

import { environment } from '../../../environments/environment';
import { Employee } from '../components/edit-profile/models/employee.model';
import { JobTitle } from '../components/edit-profile/models/job-title.model';
import { EmployeeStatus } from '../components/edit-profile/models/employee-status.model';
import { Team } from '../components/edit-profile/models/team.model';
import { EmployeeRole } from '../components/edit-profile/models/employee-roles.model';



@Injectable()
export class EditService {
    
    constructor (private http: HttpClient){}

    ContentTypeHeader = new HttpHeaders ({
          'Content-Type':  'application/json'});

    updateEmployee(employee: Employee): Observable<Employee> {
        console.log("Service works");
        console.log(employee.TeamName);
        console.log(employee.TeamId);
        let requestUrl = environment.baseUrl + '/employees';
        const data = JSON.stringify(employee);

        return this.http.put<Employee>(requestUrl, data, { headers: this.ContentTypeHeader }).map(() => employee);
    }
    
    addEmployee(employee: Employee): Observable<Employee> {
        console.log("Service works");
        let requestUrl = environment.baseUrl + '/employees';
        const data = JSON.stringify(employee);

        return this.http.post<Employee>(requestUrl, data, { headers: this.ContentTypeHeader }).map(() => employee);
    }

    getEmployee(): Observable<Employee> {
        let currentUrl = '/employees/current';
        let requestUrl = environment.baseUrl + currentUrl;
        return this.http.get<Employee>(`${requestUrl}`);
    }

    getEmployeeId(id: string): Observable<Employee> {
        let idUrl = id;
        console.log(id);
        console.log(idUrl);
        let currentUrl;
        if(idUrl == null)
        {
            currentUrl = '/employees/current';
        }
        else
        {
            currentUrl = '/employees/' + idUrl;
        }
        let requestUrl = environment.baseUrl + currentUrl;
        return this.http.get<Employee>(`${requestUrl}`);
    }

    getJobTitle(): Observable<JobTitle[]> {
        let requestUrl = environment.baseUrl + '/jobtitles';
        return this.http.get<JobTitle[]>(`${requestUrl}`);
    }

    getEmployeeStatus(): Observable<EmployeeStatus[]> {
        let requestUrl = environment.baseUrl + '/employeestatus';
        return this.http.get<EmployeeStatus[]>(`${requestUrl}`);
    }

    getEmployeeRole(): Observable<EmployeeRole[]> {
        let requestUrl = environment.baseUrl + '/roles';
        return this.http.get<EmployeeRole[]>(`${requestUrl}`);
    }

    getTeam(): Observable<Team[]> {
        let requestUrl = environment.baseUrl + '/teams';
        return this.http.get<Team[]>(`${requestUrl}`);
    }
}

