import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { AuthService } from 'src/app/services/authentication/auth.service';
import { JwtService } from 'src/app/services/authentication/jwt.service';
import { Login_User } from 'src/app/shared/contracts/users/login_user';
import { User } from 'src/app/shared/entities/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private authService: AuthService,
    spinner: NgxSpinnerService,
    private jwtService: JwtService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    super(spinner)
  }

  // reactive form
  ourform: FormGroup;

  ngOnInit(): void {
    this.ourform = this.formBuilder.group({
      userName: ["", [Validators.required, Validators.maxLength(20), Validators.minLength(2)]],
      password: ["", [Validators.required, Validators.maxLength(25), Validators.minLength(8)]],
    })
  }

  get validatorsErrors() {
    return this.ourform.controls;
  }

  async onSubmit(user: User) {
    this.showSpinner(SpinnerType.BallSpinClockwiseFadeRotating);
    const result: Login_User = await this.authService.login(user.userName, user.password, () => {
      this.jwtService.identityCheck();
      this.activatedRoute.queryParams.subscribe(params => {
        const returnUrl: string = params["returnUrl"];
        if (returnUrl)
          this.router.navigate([returnUrl]);
      });
      this.hideSpinner(SpinnerType.BallSpinClockwiseFadeRotating);
    });
  }
  /*userName: string, password: string*/
}
