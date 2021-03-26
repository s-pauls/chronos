import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUser: User;
  private userSubject = new Subject<User>();
  user$ = this.userSubject.asObservable();
  constructor(private http: HttpClient) {
  }

  user(): Observable<User> {
    if (this.currentUser) {
      return of<User>(this.currentUser);
    }

    return this.http.get<User>('/api/user/user')
    .pipe(
      map(user => {
        this.currentUser = user;
        this.userSubject.next(user);
        return user;
      })
    );
  }

  singIn(token: Token) {
    this.currentUser = null;
    this.userSubject.next(this.currentUser);
    return this.http.post('/api/user/user/signin', token);
  }

  signOut() {
    this.currentUser = null;
    this.userSubject.next(this.currentUser);
    return this.http.post('/api/user/user/signout', {});
  }
}

export interface Token {
  accessToken: string;
  expiration: string;
}

export interface User {
  displayName: string;
  id: string;
}
