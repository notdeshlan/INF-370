import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemCategory } from '../models/items.model';
import { ItemType } from '../models/items.model';
import { Item } from '../models/items.model';

@Injectable({
    providedIn: 'root'
  })
  export class ItemCategoryService {
    private apiUrl = 'https://localhost:7290/api/ItemCategories'; 
  
    constructor(private http: HttpClient) { }
    getAll(): Observable<ItemCategory[]> {
      return this.http.get<ItemCategory[]>(this.apiUrl);
    }
    create(data: any): Observable<any> {
      return this.http.post(this.apiUrl, data);
    }
    getCat(catId: any): Observable<ItemCategory> {
      return this.http.get<ItemCategory>(`${this.apiUrl}/${catId}`);
    }
    update(catId: any, data: any): Observable<any> {
      return this.http.put(`${this.apiUrl}/${catId}`, data);
    }
    delete(catId: any): Observable<any> {
      return this.http.delete(`${this.apiUrl}/${catId}`);
    }
    checkAssociatedRecords(catId: string): Observable<{ hasAssociatedRecords: boolean }> {
      const url = `${this.apiUrl}/${catId}/check-associated-records`;
      return this.http.get<{ hasAssociatedRecords: boolean }>(url);
    }
  
  }

  @Injectable({
    providedIn: 'root'
  })
  export class ItemTypeService {
    private apiUrl = 'https://localhost:7290/api/ItemTypes'; 
  
    constructor(private http: HttpClient) { }
    getAll(): Observable<ItemType[]> {
      return this.http.get<ItemType[]>(this.apiUrl);
    }
    create(data: any): Observable<any> {
      return this.http.post(this.apiUrl, data);
    }
    getType(Id: any): Observable<ItemType> {
      return this.http.get<ItemType>(`${this.apiUrl}/${Id}`);
    }
    update(Id: any, data: any): Observable<any> {
      return this.http.put(`${this.apiUrl}/${Id}`, data);
    }
    delete(Id: any): Observable<any> {
      return this.http.delete(`${this.apiUrl}/${Id}`);
    }
    checkAssociatedRecords(Id: string): Observable<{ hasAssociatedRecords: boolean }> {
      const url = `${this.apiUrl}/${Id}/check-associated-records`;
      return this.http.get<{ hasAssociatedRecords: boolean }>(url);
    }
  
  }

  @Injectable({
    providedIn: 'root'
  })
  export class ItemService {
    private apiUrl = 'https://localhost:7290/api/Items'; 
  
    constructor(private http: HttpClient) { }
    getAll(): Observable<Item[]> {
      return this.http.get<Item[]>(this.apiUrl);
    }
    create(data: any): Observable<any> {
      return this.http.post(this.apiUrl, data);
    }
    getItem(empId: any): Observable<Item> {
      return this.http.get<Item>(`${this.apiUrl}/${empId}`);
    }
    update(empId: any, data: any): Observable<any> {
      return this.http.put(`${this.apiUrl}/${empId}`, data);
    }
    delete(empId: any): Observable<any> {
      return this.http.delete(`${this.apiUrl}/${empId}`);
    }
  
  }