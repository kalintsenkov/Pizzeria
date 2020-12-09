import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { JwtService } from '../services/jwt.service';

@Injectable({
    providedIn: 'root',
})
export class TokenInterceptorService {

    constructor(private jwtService: JwtService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone({
            setHeaders: {
                Authorization: `Bearer ${this.jwtService.getToken()}`,
            },
        });

        return next.handle(request);
    }
}
