import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, tap } from 'rxjs';
import { ResultModel } from 'src/app/core/baseModel/resultModel';
import { environment } from 'src/environments/environment';
import { AuthLoginModel } from '../auth-model/authLoginModel';
import { AuthResponseModel } from '../auth-model/authResponseModel';
import { User } from '../auth-model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseAuthUrl = `${environment.baseUrl}Auth/`;
  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  user = new BehaviorSubject<User>(null)

  register(userModel: User) {
    return this.http.post<ResultModel<AuthResponseModel>>(`${this.baseAuthUrl}register`, userModel)
      .pipe(
        tap((response) => {
          let newUser: User = null
          if (response.success) {
            newUser = new User(
              userModel.email,
              userModel.firstName,
              userModel.lastName,
              null,
              response.data.token,
              response.data.expiration
            );
          }
          this.handleAuthentication(response, newUser)
        })
      )
  }

  login(loginModel: AuthLoginModel) {
    return this.http.post<ResultModel<AuthResponseModel>>(`${this.baseAuthUrl}login`, loginModel)
      .pipe(
        tap((response) => {
          let newUser: User = null
          if (response.success) {
            newUser = new User(
              loginModel.email,
              null,
              null,
              null,
              response.data.token,
              response.data.expiration
            )
          }
          this.handleAuthentication(response, newUser);
        })
      )
  }

  logout() {
    this.user.next(null);
    localStorage.removeItem("user");
    this.router.navigate(["/auth"]);
  }

  autoLogin() {
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user)
      return;

    const loadedUser = new User(
      user["email"],
      user["id"],
      user["_token"],
      user["_tokenExpirationDate"]
    );

    if (loadedUser["_token"]) {
      this.user.next(loadedUser);
    }
  }

  handleAuthentication(response: ResultModel<AuthResponseModel>, userModel: User) {
    const expirationDate = new Date(response.data.expiration);
    const user = userModel
    this.user.next(user);
    localStorage.setItem("user", JSON.stringify(user));
  }
}
