import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestOfWork, RequestOfWorkFilter, RequestOfWorkStatusItem, RequestOfWorkTypeItem } from '../models';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class RequestOfWorkService {
  private apiUrl = '';

  constructor(
    private config: AppConfigService,
    private httpClient: ChronosHttpClientService
    ) {
      this.apiUrl = `${config.getData('apiEndpoint')}/requests-of-work`;
  }

  getList(filter?: RequestOfWorkFilter): Observable<RequestOfWork[]>{
    let url = this.apiUrl;
    let params = new HttpParams();

    if (filter) {    
      if (filter.requestOfWorkIds && filter.requestOfWorkIds.length > 0) {
        filter.requestOfWorkIds.forEach(x => params = params.append('requestOfWorkId', x.toString()));
      }

      if (filter.statusIds && filter.statusIds.length > 0) {
        filter.statusIds.forEach(x => params = params.append('statusId', x.toString()));
      }

      if (filter.typeIds && filter.typeIds.length > 0) {
        filter.typeIds.forEach(x => params = params.append('typeId', x.toString()));
      }

      if (filter.productIds && filter.productIds.length > 0) {
        filter.productIds.forEach(x => params = params.append('productId', x.toString()));
      }
    }

    return this.httpClient.get(url, { params: params });
  }  

  getStatuses(): Observable<RequestOfWorkStatusItem[]> {
    return this.httpClient.get(`${this.apiUrl}/statuses`);
  }

  getTypes(): Observable<RequestOfWorkTypeItem[]> {
    return this.httpClient.get(`${this.apiUrl}/types`);
  }
}
