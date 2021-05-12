import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Member, MemberQuery } from '../models';
import { AppConfigService } from './app-config.service';
import { ChronosHttpClientService } from './chronos-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  private apiUrl = '';

  constructor(
    private config: AppConfigService,
    private httpClient: ChronosHttpClientService
  ) {
      this.apiUrl = `${config.getData('apiEndpoint')}/members`;
  }

  getList(query?: MemberQuery): Observable<Member[]> {
    let params = new HttpParams();

    if (query) {    
      if (query.searchText && query.searchText.length > 0) {
        params = params.append('searchText', query.searchText);
      }

      if (query.memberStatusId && query.memberStatusId.length > 0) {
        query.memberStatusId.forEach(x => params = params.append('memberStatusId', x.toString()));
      }

      if (query.memberRoleId && query.memberRoleId.length > 0) {
        query.memberRoleId.forEach(x => params = params.append('memberRoleId', x.toString()));
      }

      if (query.teamUid && query.teamUid.length > 0) {
        query.teamUid.forEach(x => params = params.append('teamUid', x.toString()));
      }

      if (query.projectUid && query.projectUid.length > 0) {
        query.projectUid.forEach(x => params = params.append('projectUid', x.toString()));
      }
    }

    return this.httpClient.get<Member[]>(this.apiUrl, { params: params })
      .pipe(map((data) =>  data.map(x => new Member(x))));
  }
}
