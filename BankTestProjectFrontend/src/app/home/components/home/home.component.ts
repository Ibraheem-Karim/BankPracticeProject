import { Component } from '@angular/core';
// import { AuthService } from '../../auth/services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  constructor(
    // public authService: AuthService,
    private router: Router
  ) {}

  navigateTo(route: string): void {
    this.router.navigate([route]);
  }
}
