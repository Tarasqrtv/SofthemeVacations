import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { UUID } from 'angular2-uuid';
import 'rxjs/add/operator/map';
import { environment } from '../../../environments/environment';

@Injectable()
export class ImageService {
    constructor (private http: HttpClient) { }

    postFile(url: string, file: File, newFileName: string): Observable<File> {
        let formData:FormData = new FormData();
        formData.append(newFileName, file, file.name);
        let headers = new HttpHeaders();
        
        headers.append('Content-Type', 'multipart/form-data');

        return this.http.post<File>(url, formData, { headers: headers });
    }

    getImgUrl(): Observable<string> {
        let requestUrl = environment.baseUrl + '/images/current';
        return this.http.get<string>(`${requestUrl}`);
    }
}