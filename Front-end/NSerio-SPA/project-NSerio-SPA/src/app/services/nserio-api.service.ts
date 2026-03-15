import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NserioApiService {

  private readonly apiUrl = 'https://localhost:7231/api/';

  constructor(private http: HttpClient) {}

  // GET ALL
  getAppNSerio<T>(url: string): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}${url}`).pipe(
      map(res => res),
      catchError(error => {
        console.error('Error GET AppNSerios:', error);
        return throwError(() => error);
      })
    );
  }

  // GET BY ID
  getAppNSerioById<T>(url: string, id: number): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}${url}/${id}`).pipe(
      map(res => res),
      catchError(error => {
        console.error('Error GET AppNSerio:', error);
        return throwError(() => error);
      })
    );
  }

  // POST
  createAppNSerio<T>(url: string, AppNSerio: T): Observable<T> {
    return this.http.post<T>(`${this.apiUrl}${url}`, AppNSerio).pipe(
      map(res => res),
      catchError(error => {
        console.error('Error POST AppNSerio:', error);
        return throwError(() => error);
      })
    );
  }

  // PUT
  updateAppNSerio<T>(url: string, id: number, Body: T): Observable<T> {
    return this.http.put<T>(`${this.apiUrl}${url}/${id}`, Body).pipe(
      map(res => res),
      catchError(error => {
        console.error('Error PUT AppNSerio:', error);
        return throwError(() => error);
      })
    );
  }

  // DELETE
  deleteAppNSerio(url: string, id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}${url}/${id}`).pipe(
      catchError(error => {
        console.error('Error DELETE AppNSerio:', error);
        return throwError(() => error);
      })
    );
  }
}
