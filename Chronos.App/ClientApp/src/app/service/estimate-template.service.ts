import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EstimateTemplate } from '../models';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class EstimateTemplateService {
  private apiUrl = '';

  constructor(private config: AppConfigService,
    private httpClient: ChronosHttpClientService) {
      this.apiUrl = `${config.getData('apiEndpoint')}/estimate-templates`;
  }

  getList(): Observable<EstimateTemplate[]> {
    return this.httpClient.get(this.apiUrl);
  }
}
