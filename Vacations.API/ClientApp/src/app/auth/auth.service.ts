import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './auth.model';

@Injectable()
export class AuthService {

    constructor(private http: HttpClient) { }

    user = {
        email: '',
        password: ''
    };

    get(url, user) : Observable<User>{
        let headers = new HttpHeaders();
        headers = headers.append('Authorization', 'Basic ' + btoa(user.email + ':' + user.password));
        headers = headers.append("Content-Type", "application/x-www-form-urlencoded");

        return this.http.get<User>(url, {
            headers: headers
        });
    }
}
