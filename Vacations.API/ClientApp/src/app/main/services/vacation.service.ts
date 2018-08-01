import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import {environment} from '../../../environments/environment';
import { Vacation } from '../components/profile/my-vacations/vacation.model';
import { VacModel } from '../components/request-vacation/vacation-request/vacation-request.model';

@Injectable()
export class VacationService {
    constructor (private http: HttpClient) { }

    getVacations(): Observable<Vacation[]> {
        let requestUrl = environment.baseUrl + '/vacations/employee';
        return this.http.get<Vacation[]>(`${requestUrl}`);
    }

    SendVacation(vacation: VacModel): Observable<VacModel> {
        console.log("Service works");
        let requestUrl = environment.baseUrl + '/vacations/employee';
        const data = JSON.stringify(vacation);

        let headers = new HttpHeaders();
        
        headers.append('Content-Type', 'application/json');

        return this.http.post(requestUrl, data, { headers: headers }).map(() => vacation);
    }
}

   

