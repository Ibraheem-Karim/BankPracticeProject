import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sing-up',
  standalone: false,
  templateUrl: './sing-up.component.html',
  styleUrl: './sing-up.component.css',
})
export class SingUpComponent implements OnInit {
  signUpForm!: FormGroup; // ✅ declare without initializing

  successMessage = '';
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  onSubmit(): void {
    if (this.signUpForm.invalid) return;

    this.authService.register(this.signUpForm.value).subscribe({
      next: (res) => {
        this.successMessage = res.message;
        this.errorMessage = '';
        this.signUpForm.reset();

        this.router.navigate(['/customer/sign-in']); // redirect to sign-in after successful registration
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'Registration failed.';
        this.successMessage = '';
      },
    });
  }
}
