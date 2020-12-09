import { Injectable } from '@angular/core';

import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class JwtService {

    private key = 'token';

    saveToken(token: string): void {
        localStorage.setItem(this.key, token);
    }

    getToken(): string {
        return localStorage.getItem(this.key);
    }

    removeToken(): void {
        return localStorage.removeItem(this.key);
    }

    decode(): any {
        const jwt = this.getToken();

        if (!jwt) {
            return null;
        }

        const helper = new JwtHelperService();
        const decodedToken = helper.decodeToken(jwt);

        return decodedToken;
    }
}
