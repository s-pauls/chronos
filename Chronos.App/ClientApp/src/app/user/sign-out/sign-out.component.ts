import { Component } from '@angular/core';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sigout',
  template: ''
})
export class SignOutComponent {

  constructor(private authService: AuthService, private router: Router) {
    this.authService.signOut()
    .subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
