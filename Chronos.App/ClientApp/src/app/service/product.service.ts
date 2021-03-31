import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/Product';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = '';

  constructor(private config: AppConfigService,
              private httpClient: ChronosHttpClientService) {
    this.apiUrl = `${config.getData('apiEndpoint')}/products`;
  }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get(this.apiUrl);
  }
}
