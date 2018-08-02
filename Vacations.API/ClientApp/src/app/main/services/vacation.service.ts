import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import {environment} from '../../../environments/environment';
import { Vacation } from '../components/profile/my-vacations/vacation.model';
import { VacModel } from '../components/request-vacation/vacation-request/vacation-request.model';
import { VacRequest } from '../components/list-of-vacation-requests/vacation-request.model';
import { VacType } from '../components/request-vacation/vacation-request/vacation-types.model';

@Injectable()
export class VacationService {
    constructor (private http: HttpClient) { }

    ContentTypeHeader = new HttpHeaders ({
        'Content-Type':  'application/json'});

    getVacations(): Observable<Vacation[]> {
        let requestUrl = environment.baseUrl + '/vacations/employee';
        return this.http.get<Vacation[]>(`${requestUrl}`);
    }

    getVacation(vacurl: string): Observable<Vacation> {
        let requestUrl = environment.baseUrl + '/vacations/'+vacurl;
       return this.http.get<Vacation>(`${requestUrl}`);
   }

    getVacationRequests(): Observable<VacRequest[]> {
        let requestUrl = environment.baseUrl + '/vacations';
        return this.http.get<VacRequest[]>(`${requestUrl}`);
    }

    getVacationType(): Observable<VacType[]> {
        let requestUrl = environment.baseUrl + '/vacationtypes';
        return this.http.get<VacType[]>(`${requestUrl}`);
    }

    SendVacation(vacation: VacModel): Observable<VacModel> {
        console.log("Service works");
        let requestUrl = environment.baseUrl + '/vacations/employee';
        const data = JSON.stringify(vacation);

        return this.http.post<VacModel>(requestUrl, data, { headers: this.ContentTypeHeader }).map(() => vacation);
    }
}

   

