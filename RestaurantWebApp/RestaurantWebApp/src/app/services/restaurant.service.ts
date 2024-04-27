import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
    providedIn: 'root'
})

export class RestaurantService {
    baseURL = `${environment.apiUrl}`;
    constructor(private http: HttpClient) { }

    create(payload: any) {
        return this.http.post(`${this.baseURL}/restaurant`, payload);
    }
    createFormatted(payload: any) {
        return this.http.post(`${this.baseURL}/restaurant/formatter`, payload);
    }
}