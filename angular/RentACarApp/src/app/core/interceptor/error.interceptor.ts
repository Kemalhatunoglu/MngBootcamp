import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((response: HttpErrorResponse) => {
        let message: string = 'Bir hata oluştu.';
        if (!navigator.onLine) {//internet bağlantısını kontron eder.
          message = 'İnternet bağlantınızı kontrol ediniz.'
          return throwError(() => new Error(message));
        }
        if (response.error.error) {
          if (response.status === 401) {
            message = 'Yetkiniz yok.'
            return throwError(() => new Error(message));
          }
        }
        if (response.error.error) {
          switch (response.error.error.message) {
            case "EMAIL_EXISTS":
              message = "Mail adresi önceden kullanılmıştır."
              break;
            case 'EMAIL_NOT_FOUND':
              message = "Email adresi bulunamadı.";
              break;
            case 'INVALID_PASSWORD':
              message = "Hatalı şifre.";
              break;
          }
        }
        return throwError(() => new Error(message))
      })
    )
  }
}
