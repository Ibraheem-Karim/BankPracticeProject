import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

import { CreateTransactionDto } from '../../transaction/models/create-transaction.dto';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  private apiUrl = `${environment.apiUrl}/api/transactions`;

  constructor(private http: HttpClient) {}

  createTransaction(payload: CreateTransactionDto): Observable<{ message: string }> {
    return this.http.post<{ message: string }>(`${this.apiUrl}/new`, payload);
  }
}
