import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from '../service/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticatedGuard implements CanActivate {
  constructor(private accountService: AuthService, private router: Router) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return this.accountService.user()
      .pipe(
        map(user => {
          if (user) {
            return true;
          }
          this.router.navigate(['/User/SignIn']);

          return false;
        })
      );
  }
}
