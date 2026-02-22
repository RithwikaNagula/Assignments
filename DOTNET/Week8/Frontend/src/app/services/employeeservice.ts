import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateEmployeeRequest, EmployeeInfo } from '../models/employee';

@Injectable({
    providedIn: 'root',
})
export class EmployeeService {
    private readonly apiUrl = 'http://localhost:5004/api/employees';

    constructor(private http: HttpClient) { }

    getAll(): Observable<EmployeeInfo[]> {
        return this.http.get<EmployeeInfo[]>(this.apiUrl);
    }

    getById(id: number): Observable<EmployeeInfo> {
        return this.http.get<EmployeeInfo>(`${this.apiUrl}/${id}`);
    }

    create(request: CreateEmployeeRequest): Observable<EmployeeInfo> {
        return this.http.post<EmployeeInfo>(this.apiUrl, request);
    }

    update(id: number, request: CreateEmployeeRequest): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${id}`, request);
    }

    delete(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}
