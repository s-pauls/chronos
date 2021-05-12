import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BlankFeature } from '../models';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class BlankFeatureService {
  private apiUrl = '';

  constructor(private config: AppConfigService,
    private httpClient: ChronosHttpClientService) {
      this.apiUrl = `${config.getData('apiEndpoint')}/blank-features`;
  }

  get(id: number): Observable<BlankFeature> {
    return this.httpClient.get(`${this.apiUrl}/${id}`);
  }
}
