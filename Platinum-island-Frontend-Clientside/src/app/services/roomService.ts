import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RoomType } from '../models/roomType.model';

@Injectable({
    providedIn: 'root'
  })

  export class RoomTypeService {
    private apiUrl = 'https://localhost:7290/api/RoomTypes';
    constructor(private http: HttpClient) { }

    getAll(): Observable<RoomType[]> {
        return this.http.get<RoomType[]>(this.apiUrl);
      }
      create(data: any): Observable<any> {
        return this.http.post(this.apiUrl, data);
      }
      getType(TypeId: any): Observable<RoomType> {
        return this.http.get<RoomType>(`${this.apiUrl}/${TypeId}`);
      }
      update(TypeId: any, data: any): Observable<any> {
        return this.http.put(`${this.apiUrl}/${TypeId}`, data);
      }
      delete(typeId: any): Observable<any> {
        return this.http.delete(`${this.apiUrl}/${typeId}`);
      }
  }