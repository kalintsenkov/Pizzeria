import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ApiService } from './api.service';

@Injectable({
    providedIn: 'root'
})
export class AddressesService {
    private addressesPath = 'addresses';

    constructor(private api: ApiService) { }

    create(data: any): Observable<number> {
        return this.api.post(this.addressesPath, data);
    }
}
