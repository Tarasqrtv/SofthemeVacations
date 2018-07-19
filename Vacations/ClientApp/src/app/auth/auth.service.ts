import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthService {

    constructor(private http: Http) { }

    user = {
        email: '',
        password: ''
    };

    createAuthorizationHeader(headers: Headers, user) {
        headers.append('Authorization', 'Basic ' +
            btoa(user.email + ':' + user.password));
    }

    post(url, data): Observable<any> {
        let headers = new Headers();
        this.createAuthorizationHeader(headers, data);
        return this.http.post(url, null, {
            headers: headers
        });
    }
}
