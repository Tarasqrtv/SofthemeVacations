import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { environment } from '../../../environments/environment';
import { Employee } from '../components/edit-profile/models/employee.model';
import { JobTitle } from '../components/edit-profile/models/job-title.model';
import { EmployeeStatus } from '../components/edit-profile/models/employee-status.model';
import { Team } from '../components/edit-profile/models/team.model';
import { employeeRole } from '../components/edit-profile/models/employee-roles.model';

@Injectable()
export class EditService {
    constructor (private http: HttpClient) { }

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
        let requestUrl = environment.baseUrl + '/employees/current';
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

    getEmployeeRole(): Observable<employeeRole[]> {
        let requestUrl = environment.baseUrl + '/roles';
        return this.http.get<employeeRole[]>(`${requestUrl}`);
    }

    getTeam(): Observable<Team[]> {
        let requestUrl = environment.baseUrl + '/teams';
        return this.http.get<Team[]>(`${requestUrl}`);
    }
}

