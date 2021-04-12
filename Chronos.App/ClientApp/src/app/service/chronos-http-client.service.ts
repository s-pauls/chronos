import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse } from '../models';

@Injectable({
  providedIn: 'root'
})
export class ChronosHttpClientService {

  constructor(
    private httpClient: HttpClient) { }

  get<T>(url: string, options?: any): Observable<T> {
    return this.httpClient.get<ApiResponse<T>>(url, this.appendOptionsByPartnerName(options))
      .pipe(map(result => {        
        return result.data;
      }));
  }

  post(url: string, data: any, options?: any): Observable<any> {
    return this.httpClient.post(url, data, this.appendOptionsByPartnerName(options));
  }

  put(url: string, data: any, options?: any): Observable<any> {
    return this.httpClient.put(url, data, this.appendOptionsByPartnerName(options));
  }

  delete(url: string, options?: any): Observable<any> {
    return this.httpClient.delete(url, this.appendOptionsByPartnerName(options))
  }

  private appendOptionsByPartnerName(options: any): Object {
    var header = new HttpHeaders({ 'Cache-Control': 'no-cache', Pragma: 'no-cache' });
    
    if (!options) {
      options = { headers: header };      
    }

    if (!options.headers) {
      options.headers = header;    
    }

    return options;    
  }
}
