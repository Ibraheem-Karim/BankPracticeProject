import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';
import { AccountService } from '../../../core/services/account.service';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  accounts: any[] = [];

  constructor(
    public authService: AuthService,
    private router: Router,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    if (this.authService.isLoggedIn()) {
      const customerId = this.authService.getUserId(); 
      this.accountService.getAccountsByCustomerId(customerId!).subscribe({
        next: (res) => (this.accounts = res),
      });
    }
  }

  navigateTo(route: string): void {
    this.router.navigate([route]);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
