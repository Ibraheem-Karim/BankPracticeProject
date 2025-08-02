import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { TransactionService } from '../../../core/services/transaction.service';
import { AuthService } from '../../../core/services/auth.service';



@Component({
  selector: 'app-new-transaction',
  standalone: false,
  templateUrl: './new-transaction.component.html',
  styleUrl: './new-transaction.component.css'
})

export class NewTransactionComponent implements OnInit {
  transactionForm!: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private transactionService: TransactionService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.transactionForm = this.fb.group({
      toAccountNumber: ['', Validators.required],
      amount: [0, [Validators.required, Validators.min(1)]],
      transactionType: ['', Validators.required],
      description: ['']
    });
  }

  submitTransaction() {
  if (this.transactionForm.invalid) return;

  this.authService.getAccountNumberFromApi().subscribe({
    next: (fromAccountNumber) => {
      const payload = {
        ...this.transactionForm.value,
        fromAccountNumber
      };

      this.transactionService.createTransaction(payload).subscribe({
        next: (res: any) => {
          this.successMessage = res.message;
          this.errorMessage = '';
          this.transactionForm.reset();
        },
        error: (err) => {
          this.successMessage = '';
          this.errorMessage = err.error?.message || 'Transaction failed';
        }
      });
    },
    error: () => {
      this.errorMessage = 'Unable to fetch account number';
    }
  });
}

}
