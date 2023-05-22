import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Supplier } from '../models/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class SuppService {
  private apiUrl = 'https://localhost:7290/api/Suppliers';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Supplier[]> {
    return this.http.get<Supplier[]>(this.apiUrl);
  }
  create(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
  getSupp(suppId: any): Observable<Supplier> {
    return this.http.get<Supplier>(`${this.apiUrl}/${suppId}`);
  }
  update(suppId: any, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${suppId}`, data);
  }
  delete(supplierId: any): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${supplierId}`);
  }
}
