import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ApiService } from './api.service';
import { ICartPizza } from '../models/cartPizza.model';
import { Size } from '../common/size.enum';

@Injectable({
    providedIn: 'root'
})
export class CartsService {
    private cartsPath = 'shoppingcarts/';

    constructor(private api: ApiService) { }

    mine(): Observable<Array<ICartPizza>> {
        return this.api.get(this.cartsPath);
    }

    total(): Observable<number> {
        return this.api.get(this.cartsPath + 'total');
    }

    addPizza(id: number, quantity: number = 1, size: Size = Size.Small) {
        return this.api.post(this.cartsPath, {
            pizzaId: id,
            quantity: quantity,
            size: size
        });
    }

    updatePizza(id: number, quantity: number) {
        return this.api.put(this.cartsPath, {
            pizzaId: id,
            quantity: quantity
        });
    }

    removePizza(id: number) {
        return this.api.delete(this.cartsPath + id);
    }
}
