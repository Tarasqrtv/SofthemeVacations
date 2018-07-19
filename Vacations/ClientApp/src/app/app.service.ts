import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class MyDataService {
    constructor(private http: HttpClient) { }

    get<T>(url: string): Observable<T> {
        return this.http.get<T>(url);
    }

    post<T>(url: string, body: string): Observable<T> {
        return this.http.post<T>(url, body);
    }

    put<T>(url: string, body: string): Observable<T> {
        return this.http.put<T>(url, body);
    }

    delete<T>(url: string): Observable<T> {
        return this.http.delete<T>(url);
    }

    patch<T>(url: string, body: string): Observable<T> {
        return this.http.patch<T>(url, body);
    }
}


@Injectable()
export class MyFirstInterceptor implements HttpInterceptor {

    constructor() { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        console.log(JSON.stringify(req));

        if (localStorage.getItem('token')) {
            req = req.clone({ headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))});
        }

        if (!req.headers.has('Content-Type')) {
            req = req.clone({ headers: req.headers.set('Content-Type', 'application/json') }); 
        }

        req = req.clone({ headers: req.headers.set('Accept', 'application/json') });
        return next.handle(req);
    }
}