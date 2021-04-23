import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentModel } from '../models';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class RequestsOfWorkCommentsService {
  private apiUrl = '';

  constructor(
    private config: AppConfigService,
    private httpClient: ChronosHttpClientService
    ) {
      this.apiUrl = `${config.getData('apiEndpoint')}/requests-of-work`;
  }
  
  getList(requestOfWorkId: number): Observable<CommentModel[]> {
    return this.httpClient.get(`${this.apiUrl}/${requestOfWorkId}/comments`);
  }

  add(requestOfWorkId: number, comment: string): Observable<CommentModel[]> {
    return this.httpClient.post(`${this.apiUrl}/${requestOfWorkId}/comments`, { message: comment });
  }
}
