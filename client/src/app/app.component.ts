import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtService } from './services/authentication/jwt.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {


  constructor(public jwtService: JwtService, private router: Router) {
    jwtService.identityCheck();
  }

  signOut(){
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("randid");
    this.jwtService.identityCheck();
    this.router.navigate([""]);
  }
}
