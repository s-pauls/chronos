import { Component, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/service';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-sigout',
  template: ''
})
export class SignOutComponent implements OnDestroy {
  private destroy: Subject<void> = new Subject<void>();

  constructor(private authService: AuthService, private router: Router) {
    this.authService.signOut()
      .pipe(takeUntil(this.destroy))
      .subscribe(() => {
        this.router.navigate(['User/SignIn']);
      });
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
