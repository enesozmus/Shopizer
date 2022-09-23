import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs';
import { SpinnerType } from '../base/base.component';
import { _isAuthenticated } from '../services/authentication/jwt.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private router: Router, private spinner: NgxSpinnerService) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    // spinner
    this.spinner.show(SpinnerType.BallSpinClockwiseFadeRotating);

    /*
    // localStorage & token
    const token: string = localStorage.getItem("accessToken");
    // süre kontrolü
    let expired: boolean;

    // check
    try {
      expired = this.jwtHelper.isTokenExpired(token);
    } catch {
      expired = true;
    }
      //const decodeToken = this.jwtHelper.decodeToken(token);
      //const expirationDate: Date = this.jwtHelper.getTokenExpirationDate(token);
    */

    if (!_isAuthenticated) {

      // state.url → gitmek istenen url
      this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });

      //alert("Yetkisiz Erişim! → Oturum açmanız gerekiyor!");
    }
    this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating);
    return true;


  }

}
