import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/authentication/auth.service';
import { Register_User } from 'src/app/shared/contracts/users/register_user';
import { User } from 'src/app/shared/entities/user';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {

  constructor(private formBuilder: UntypedFormBuilder, private authService: AuthService, private router: Router) { }

  // reactive form
  ourform: UntypedFormGroup;


  ngOnInit(): void {
    this.ourform = this.formBuilder.group({
      firstName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(2)]],
      lastName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(2)]],
      userName: ["", [Validators.required, Validators.maxLength(20), Validators.minLength(2)]],
      email: ["", [Validators.required, Validators.email, Validators.maxLength(20), Validators.minLength(4)]],
      password: ["", [Validators.required, Validators.maxLength(25), Validators.minLength(8)]],
      PasswordConfirm: ["", [Validators.required, Validators.maxLength(25), Validators.minLength(8)]],
    }, {
      validators: (group: AbstractControl): ValidationErrors | null => {
        let passwordFirst = group.get("password").value;
        let passwordSecond = group.get("PasswordConfirm").value;
        return passwordFirst === passwordSecond ? null : { notSame: true };
      }
    });
  }

  async onSubmit(user: User) {
    // register operation
    // user => form'dan gelen user.
    const result: Register_User = await this.authService.register(user);
    if (result.isSucceeded)
    {
      this.router.navigateByUrl('/products');
    }
    else
      alert(result.message);
  }

  // hataları döner
  get validatorsErrors() {
    return this.ourform.controls;
  }

}
