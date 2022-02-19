import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpParams
} from '@angular/common/http';
import { exhaustMap, take } from 'rxjs';
import { AuthService } from 'src/app/auths/auth-service/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    return this.authService.user
      .pipe(
        take(1),
        exhaustMap(user => {
          if (!user) {
            return next.handle(request);
          }
          const updatedReq = request.clone({
            params: new HttpParams().set("auth", user["_token"])
          })
          return next.handle(updatedReq)
        })
      )
  }
}
