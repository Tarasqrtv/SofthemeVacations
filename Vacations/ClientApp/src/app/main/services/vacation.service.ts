import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Vacation } from '../components/vacation/vacation.model';

const requestUrl = 'http://btangular.azurewebsites.net/api/vacations/';

@Injectable()
export class VacationService {
    constructor (private http: HttpClient) { }

    getVacations(): Observable<Vacation[]> {
        return this.http.get<Vacation[]>(`${requestUrl}`);
    }
}

   

