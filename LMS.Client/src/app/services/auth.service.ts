import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { LoginRequest } from '../interfaces/login-request';
import { BehaviorSubject, map, Observable, retry, Subject } from 'rxjs';
import { AuthResponse } from '../interfaces/auth-response';
import { HttpClient } from '@angular/common/http';
import {jwtDecode} from 'jwt-decode';
import { RegisterRequest } from '../interfaces/register-request';
import { UserDetail } from '../interfaces/user-detail';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl: string = environment.apiUrl;
  private tokenKey  = 'token';

  private userLoggedInSubject: BehaviorSubject<boolean>;
  userLoggedIn$: Observable<boolean>;

  private userDetailSubject : BehaviorSubject<UserDetail | null>;
  userDetail$ : Observable<UserDetail | null>;

  constructor(private http: HttpClient) {
    this.userLoggedInSubject = new BehaviorSubject<boolean>(this.hasValidToken());
    this.userLoggedIn$ = this.userLoggedInSubject.asObservable();
    this.userDetailSubject = new BehaviorSubject<UserDetail | null>(this.getUserDetail());
    this.userDetail$ = this.userDetailSubject.asObservable();
   }
   
  login(data: LoginRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/account/login`, data)
    .pipe(
      map((response) => {
        if (response && response.isSuccess) {
          localStorage.setItem(this.tokenKey, response.token || '');
          this.userLoggedInSubject.next(true);
          this.userDetailSubject.next(this.getUserDetail());
        }
        return response;
      })
    );
  }

  register(data: RegisterRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/account/register`, data)
    .pipe(
      map((response) => {
        return response;
      })
    );
  }
  
  getUserDetail=() : UserDetail | null =>{
    const token = this.getToken();
    if(!token) return null;
    const decodedToken:any = jwtDecode(token);
    const userDetail: UserDetail ={
      id:decodedToken.nameid,
      email:decodedToken.email,
      firstName:decodedToken.given_name,
      lastName:decodedToken.family_name,
      role: decodedToken.role
    }
    return userDetail;
  }

  hasValidToken = ():boolean => {
    const token = this.getToken();
    if(!token) return false;
    return !this.isTokenExpired();
  }

  
 private isTokenExpired() {
   const token = this.getToken();
   if(!token) return true;
   const decoded = jwtDecode(token); 
   const isTokenExpired  = Date.now() >= decoded['exp']! * 1000;
   if(isTokenExpired) this.logout();
   return isTokenExpired;
  }

  logout =():void =>{
    localStorage.removeItem(this.tokenKey);
    this.userLoggedInSubject.next(false);
    this.userDetailSubject.next(null);
  }

  getToken = (): string | null => localStorage.getItem(this.tokenKey) || '';
  
}

