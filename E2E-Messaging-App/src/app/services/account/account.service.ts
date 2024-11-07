import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel, RegisterModel } from '../../generated';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private httpClient: HttpClient) {}

  public registerAccount(registerModel: RegisterModel): Observable<string> {
    return this.httpClient.post<string>(
      `${environment.apiUrl}/api/account/register`,
      registerModel,
      { responseType: 'text' as 'json' });
  }

  public login(loginModel: LoginModel): Observable<any> {
    return this.httpClient.post<any>(`${environment.apiUrl}/api/account/login`, loginModel);
  }

  public checkUsername(username: string): Observable<boolean> {
    return this.httpClient.get<boolean>(`${environment.apiUrl}/api/account/check-username/${username}`);
  }
}
