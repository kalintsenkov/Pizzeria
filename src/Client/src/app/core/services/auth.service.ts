import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ApiService } from './api.service';
import { JwtService } from './jwt.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {

    private identityPath = 'identity/';
    private loginPath = this.identityPath + 'login';
    private registerPath = this.identityPath + 'register';

    constructor(
        private api: ApiService,
        private jwtService: JwtService
    ) { }

    login(data): Observable<any> {
        return this.api.post(this.loginPath, data);
    }

    register(data): Observable<any> {
        return this.api.post(this.registerPath, data);
    }

    isAdministrator(): boolean {
        const decoded = this.jwtService.decode();

        if (!decoded) {
            return false;
        }

        return decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] == 'Administrator';
    }

    isAuthenticated(): boolean {
        if (this.jwtService.getToken()) {
            return true;
        }

        return false;
    }
}
