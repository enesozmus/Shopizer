import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})

export class JwtService {

  constructor(private jwtHelper: JwtHelperService) { }


  identityCheck() {

    // token
    const token: string = localStorage.getItem("accessToken");
    // expired → süresi bitmiş, geçerliliği kalkmış
    let expired: boolean;

    try {
      expired = this.jwtHelper.isTokenExpired(token);
    } catch {
      expired = true;
    }

    _isAuthenticated = token != null && !expired;
  }


  get isAuthenticated(): boolean {
    return _isAuthenticated;
  }

}

// global variable
export let _isAuthenticated: boolean;