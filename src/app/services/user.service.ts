import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginRequest } from '../requests/login-request';
import { SignupRequest } from '../requests/signup-request';
import { TokenResponse } from '../responses/token-response';
import { UserResponse } from '../responses/user-response';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  //The user service includes the http calls to our backend users controller which has the endpoints including 
  //login, signup, logout, refreshToken and getUserInfo.


  /*these methods don’t do actions (http calls) once they are called, the actions happen once you call the subscribe method on them, 
  only then the http call gets triggered and a response is returned either to the next part (success) or error part (fail), 
  and the third section which is the complete part, it is triggered in both cases, 
  this is where you can put finalizing logic such as stopping a progress bar from loading.*/

  constructor(private httpClient:HttpClient) {

   }

   login(loginRequest: LoginRequest): Observable<TokenResponse> {
    return this.httpClient.post<TokenResponse>(`${environment.apiUrl}/users/login`, loginRequest);
  }

  signup(signupRequest: SignupRequest) {
    return this.httpClient.post(`${environment.apiUrl}/users/signup`, signupRequest, { responseType: 'text'}); // response type specified, because the API response here is just a plain text (email address) not JSON
  }

  refreshToken(session: TokenResponse) {
    let refreshTokenRequest: any = {
      UserId: session.userId,
      RefreshToken: session.refreshToken
    };
    return this.httpClient.post<TokenResponse>(`${environment.apiUrl}/users/refresh_token`, refreshTokenRequest);
  }

  logout() {
    return this.httpClient.post(`${environment.apiUrl}/users/signup`, null);
  }

  getUserInfo(): Observable<UserResponse> {
    return this.httpClient.get<UserResponse>(`${environment.apiUrl}/users/info`);
  }

}
