import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { map, Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = `${environment.apiUrl}/api/auth`;

  constructor(private http: HttpClient) {}

  register(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, data);
  }

  login(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, data).pipe(
      tap((res: any) => {
        if (res.data?.token) {
          localStorage.setItem('token', res.data.token); // store token on successful login
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    console.log('JWT Token:', localStorage.getItem('token'));
    return localStorage.getItem('token');
  }

  getUserId(): string | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));

      // Direct access to the full URI claim key
      return (
        payload[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ] || null
      );
    } catch (e) {
      console.error('Failed to decode JWT', e);
      return null;
    }
  }

  getAccountNumberFromApi(): Observable<string> {
  return this.http.get<{ data: string }>(`${this.apiUrl}/account-number`).pipe(
    map(res => res.data)
  );
}


}
