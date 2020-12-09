import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root',
})
export class ApiService {

    constructor(private http: HttpClient) { }

    get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
        return this.http
            .get(`${environment.apiUrl}${path}`, { params })
            .pipe(catchError(this.formatErrors));
    }

    put(path: string, body: Object = {}): Observable<any> {
        return this.http
            .put(`${environment.apiUrl}${path}`, body)
            .pipe(catchError(this.formatErrors));
    }

    post(path: string, body: Object = {}): Observable<any> {
        return this.http
            .post(`${environment.apiUrl}${path}`, body)
            .pipe(catchError(this.formatErrors));
    }

    delete(path: string): Observable<any> {
        return this.http
            .delete(`${environment.apiUrl}${path}`)
            .pipe(catchError(this.formatErrors));
    }

    private formatErrors(error: any): Observable<never> {
        return throwError(error.error);
    }
}
