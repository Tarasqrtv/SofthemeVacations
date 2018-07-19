import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Employee } from '../components/profile/employee.model';
import { environment } from '../../../environments/environment';

@Injectable()
export class EmployeeService {
    constructor (private http: HttpClient) { }

    getEmployee(): Observable<Employee> {
        let requestUrl = environment.baseUrl + '/employees/122538d2-493a-4dfd-bdbc-1ef05b022672';
        return this.http.get<Employee>(`${requestUrl}`);
    }
}