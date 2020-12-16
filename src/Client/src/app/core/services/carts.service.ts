import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ApiService } from './api.service';
import { ICartProduct } from '../interfaces/ICartProduct';

@Injectable({
    providedIn: 'root'
})
export class CartsService {
    private cartsPath = 'shoppingcarts/';

    constructor(private api: ApiService) { }

    mine(): Observable<Array<ICartProduct>> {
        return this.api.get(this.cartsPath);
    }

    totalProducts(): Observable<number> {
        return this.api.get(this.cartsPath + 'totalproducts');
    }

    addProduct(id, quantity) {
        return this.api.post(this.cartsPath, { productId: id, quantity: quantity });
    }

    updateProduct(id, quantity) {
        return this.api.put(this.cartsPath, { productId: id, quantity: quantity });
    }

    removeProduct(id) {
        return this.api.delete(this.cartsPath + id);
    }
}
