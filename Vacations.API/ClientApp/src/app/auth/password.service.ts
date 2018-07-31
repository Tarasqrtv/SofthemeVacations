import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Info } from './reset-password/info.model';
import { environment } from '../../environments/environment';
import { Mail } from './send-reset/mail.model';



@Injectable()
export class PasswordService {
    
    constructor (private http: HttpClient){}

    ContentTypeHeader = new HttpHeaders ({
          'Content-Type':  'application/json'});

    updateUserInfo(usInfo: Info): Observable<Info> {
        console.log("Password service works");
        console.log(usInfo.Password);
        let requestUrl = environment.baseUrl + '/auth/reset-password';
        const data = JSON.stringify(usInfo);

        return this.http.put<Info>(requestUrl, data, { headers: this.ContentTypeHeader }).map(() => usInfo);
    }

    sendEmail(usIuserMail: Mail): Observable<Mail> {
        console.log("Mail service works");
        console.log(usIuserMail.email);
        let requestUrl = environment.baseUrl + '/auth/forgot-password';
        const data = JSON.stringify(usIuserMail);
    
        return this.http.post<Mail>(requestUrl, data, { headers: this.ContentTypeHeader }).map(() => usIuserMail);
    }
}

