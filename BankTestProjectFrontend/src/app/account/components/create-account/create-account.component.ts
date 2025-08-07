import { Component, OnInit } from '@angular/core';

import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-create-account',
  standalone: false,
  templateUrl: './create-account.component.html',
  styleUrl: './create-account.component.css',
})
export class CreateAccountComponent implements OnInit {
  accountForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.accountForm = this.fb.group({
      accountNumber: ['', Validators.required],
      balance: [0, [Validators.required, Validators.min(0)]],
      isActive: [false],
    });
  }

  onSubmit() {
    if (this.accountForm.invalid) return;

    const customerId = this.authService.getUserId();
    if (!customerId) return;

    const payload = {
      ...this.accountForm.value,
      customerId,
    };

    this.accountService.createAccount(payload).subscribe(() => {
      this.accountService
        .getAccountsByCustomerId(customerId)
        .subscribe(() => {});

      this.router.navigate(['/home']);
    });

    // this.accountService.createAccount(payload).subscribe(() => {
    //   this.router.navigate(['/home']);
    // });
  }
}
