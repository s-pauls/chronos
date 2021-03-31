import { HttpClient } from '@angular/common/http';
import { Injectable, isDevMode } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  public config: Object = null;
  constructor(private http: HttpClient) {}

  public getData(key: any): any {
    return this.config[key];
  }

  public load(): Promise<boolean> {
    return new Promise((resolve, reject) => {
      let configUrl = '';
      if (isDevMode()) {
        configUrl = './assets/config/config.dev.json';
      }
      else {
        configUrl = './assets/config/config.env.json';
      }
      this.http
        .get(configUrl)
        .pipe(
          catchError((error: any): any => {
            resolve(true);
            throwError(error.json().error || 'Server error');
          })
        )
        .subscribe((envResponse) => {
          this.config = envResponse;
          resolve(true);
        });
    });
  }
}
