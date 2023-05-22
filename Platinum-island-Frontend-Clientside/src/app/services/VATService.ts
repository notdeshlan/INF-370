import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VAT } from '../models/vat.model';

@Injectable({
  providedIn: 'root'
})
export class VatService {
  private apiUrl = 'https://localhost:7290/api/Vat';

  constructor(private http: HttpClient) { }

  getVatRecords(): Observable<VAT[]> {
    return this.http.get<VAT[]>(this.apiUrl);
  }
  create(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
  getVAT(vatId: any): Observable<VAT> {
    return this.http.get<VAT>(`${this.apiUrl}/${vatId}`);
  }
  update(vatId: any, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${vatId}`, data);
  }
}
