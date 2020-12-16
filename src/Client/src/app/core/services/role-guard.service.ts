import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root',
})
export class RoleGuardService implements CanActivate {
    constructor(
        public router: Router,
        public authService: AuthService
    ) { }

    canActivate(): boolean {
        if (!this.authService.isAuthenticated() ||
            !this.authService.isAdministrator()
        ) {
            this.router.navigate(['/login']);
            return false;
        }

        return true;
    }
}
