import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ApiService } from './api.service';

@Injectable({
    providedIn: 'root',
})
export class OrdersService {
    private ordersPath = 'orders';

    constructor(private api: ApiService) { }

    purchase(addressId: number, notes: string): Observable<string> {
        return this.api.post(this.ordersPath, { addressId, notes });
    }
}
