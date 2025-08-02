import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AccountService {
  private apiUrl = `${environment.apiUrl}/api/accounts`;

  constructor(private http: HttpClient) {}

  getAccountsByCustomerId(customerId: string) {
    return this.http.get<any[]>(`${this.apiUrl}/by-customer/${customerId}`);
  }

  createAccount(payload: {
  accountNumber: string;
  balance: number;
  isActive: boolean;
  customerId: string;
}) {
  return this.http.post(`${this.apiUrl}`, payload);
}
}
