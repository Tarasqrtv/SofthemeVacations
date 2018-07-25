import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Employee } from '../components/profile/my-profile/employee.model';
import { environment } from '../../../environments/environment';

@Injectable()
export class EmployeeService {
    constructor (private http: HttpClient) { }

    getEmployee(): Observable<Employee> {
        let requestUrl = environment.baseUrl + '/profile';
        return this.http.get<Employee>(`${requestUrl}`);
    }
}