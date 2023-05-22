import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeType } from '../models/employeeType.model';
import { Employee } from '../models/Employee.model';


@Injectable({
  providedIn: 'root'
})
export class EmployeeTypeService {
  private apiUrl = 'https://localhost:7290/api/EmployeeTypes'; 

  constructor(private http: HttpClient) { }
  getAll(): Observable<EmployeeType[]> {
    return this.http.get<EmployeeType[]>(this.apiUrl);
  }
  create(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
  getEmp(empTypeId: any): Observable<EmployeeType> {
    return this.http.get<EmployeeType>(`${this.apiUrl}/${empTypeId}`);
  }
  update(empId: any, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${empId}`, data);
  }
  delete(empId: any): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${empId}`);
  }
  checkAssociatedRecords(employeeTypeId: string): Observable<{ hasAssociatedRecords: boolean }> {
    const url = `${this.apiUrl}/${employeeTypeId}/check-associated-records`;
    return this.http.get<{ hasAssociatedRecords: boolean }>(url);
  }

}
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7290/api/Employees'; 

  constructor(private http: HttpClient) { }
  getAll(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }
  create(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
  getEmp(empId: any): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${empId}`);
  }
  update(empId: any, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${empId}`, data);
  }
  delete(empId: any): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${empId}`);
  }

}