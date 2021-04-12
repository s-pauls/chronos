import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ApiResponse } from '../models';

@Injectable({
  providedIn: 'root'
})
export class ToastrHttpInterceptorService implements HttpInterceptor {

  constructor(private toasterService: ToastrService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      tap(response => {
          if (response instanceof HttpResponse) {
            if (response.status === 200) {
              var apiResponse = response.body as ApiResponse<any>;
              if(apiResponse.successMessage) {
                this.toasterService.success('', apiResponse.successMessage);
              }
            }

            if (response.status === 204) {
              this.toasterService.success('', 'Success!');
            }
          }
      }),
      catchError((response: any) => {
          if(response instanceof HttpErrorResponse) {
            try {
              if (response.status === 400 || response.status === 422){
                var apiResponse = response.error as ApiResponse<any>;

                apiResponse.errorMessages.forEach(message => {
                  this.toasterService.error('', message);
                });                
              } else if (response.status >= 500 && response.status < 600) {
                this.toasterService.error('', 'Oops! Something Went Wrong');
              } else {
                this.toasterService.error('', response.error);
              }                 
            } catch(e) {                
                console.error(e);
            }
          }
          return of(response);
      }));
  }
}
