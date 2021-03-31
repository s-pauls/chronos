import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppConfigService } from './app-config.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = '';
  private currentUser: User;
  private userSubject = new Subject<User>();
  user$ = this.userSubject.asObservable();


  constructor(private config: AppConfigService,
              private http: HttpClient
  ) {
    this.apiUrl = `${config.getData('apiEndpoint')}/user`;
  }

  user(): Observable<User> {
    if (this.currentUser) {
      return of<User>(this.currentUser);
    }

    return this.http.get<User>(this.apiUrl)
    .pipe(
      map(user => {
        this.currentUser = user;
        this.userSubject.next(user);
        return user;
      })
    );
  }

  singIn(token: Token): Observable<User> {
    this.currentUser = null;
    this.userSubject.next(this.currentUser);
    return this.http.post<User>(`${this.apiUrl}/signin`, token);
  }

  signOut(): Observable<any> {
    this.currentUser = null;
    this.userSubject.next(this.currentUser);
    return this.http.post(`${this.apiUrl}/signout`, {});
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
