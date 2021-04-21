import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estimate } from '../models';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class RequestsOfWorkEstimatesService {
  private apiUrl = '';

  constructor(
    private config: AppConfigService,
    private httpClient: ChronosHttpClientService
    ) {
      this.apiUrl = `${config.getData('apiEndpoint')}/requests-of-work`;
  }
  
  getList(requestOfWorkId: number): Observable<Estimate[]> {
    return this.httpClient.get(`${this.apiUrl}/${requestOfWorkId}/estimates`);
  }
}
