import { Injectable } from "@angular/core";

import { Observable } from "rxjs";

import { ApiService } from "./api.service";
import { IPizza } from "../models/pizza.model";

@Injectable({
    providedIn: 'root',
})
export class PizzasService {
    private pizzasPath = 'pizzas/';

    constructor(private api: ApiService) { }

    all(): Observable<Array<IPizza>> {
        return this.api.get(this.pizzasPath);
    }

    search(query: string = ''): Observable<Array<IPizza>> {
        return this.api.get(this.pizzasPath + query);
    }

    details(id: number): Observable<IPizza> {
        return this.api.get(this.pizzasPath + id);
    }

    create(data: any) {
        return this.api.post(this.pizzasPath, data);
    }

    edit(id: number, data: any) {
        return this.api.put(this.pizzasPath + id, data);
    }

    delete(id: number) {
        return this.api.delete(this.pizzasPath + id);
    }
}
