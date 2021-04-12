import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FeatureRules } from '../models';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class FeatureRulesService {
  private apiUrl = '';

  constructor(private config: AppConfigService,
    private httpClient: ChronosHttpClientService) {
      this.apiUrl = `${config.getData('apiEndpoint')}/feature-rules`;
     }

  getList(): Observable<FeatureRules[]>{
    return this.httpClient.get(this.apiUrl);
  }

  getById(id: string): Observable<FeatureRules>{
    return this.httpClient.get(`${this.apiUrl}/${id}`);
  }

  getDefault(): Observable<FeatureRules>{
    return this.httpClient.get(`${this.apiUrl}/default`);
  }

  add(featureRules: FeatureRules): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}`, featureRules);
  }

  update(id: string,featureRules: FeatureRules): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${id}`, featureRules);
  }

  delete(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }
}
