import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Employee } from './employee.model';


const requestUrl = 'https://btangular.azurewebsites.net/api/employees/122538d2-493a-4dfd-bdbc-1ef05b022672';

@Injectable()
export class GetEmployeeService {
    constructor (private http: HttpClient) { }

    getEmployee(): Observable<Employee> {
        return this.http.get<Employee>(`${requestUrl}`);
    }
}
