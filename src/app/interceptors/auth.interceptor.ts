import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TokenService } from '../services/token.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  /*We are checking if the user is logged in and the request is going to our backend APIs, not some other APIs, then we will add the 
  Authorization header, with token type as bearer with the saved JWT token itself.

  In case the user is not logged in or the API call is for a different API endpoint, then we just let the request continue its normal flow 
  without any modification on it.*/


  constructor(private tokenService: TokenService) {}
 
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const requestForApis = request.url.startsWith(environment.apiUrl);
    const isLoggedIn = this.tokenService.isLoggedIn();
 
    console.log('inside intercept');
    console.log(`request is ${JSON.stringify(request.body)}`);
    if (isLoggedIn && requestForApis) {
      let session = this.tokenService.getSession();
      if (session){
        request = request.clone({ headers: request.headers.set('Authorization', `Bearer ${session.accessToken}`) });
      }
      
    }
    return next.handle(request);
  }
}
export const AuthInterceptorProvider = { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true };
