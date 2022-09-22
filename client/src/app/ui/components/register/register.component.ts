import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidationErrors } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  ourform: FormGroup;


  ngOnInit(): void {
    this.ourform = this.formBuilder.group({
      firstName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(2)]],
      lastName: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(2)]],
      userName: ["", [Validators.required, Validators.maxLength(20), Validators.minLength(2)]],
      email: ["", [Validators.required, Validators.email, Validators.maxLength(20), Validators.minLength(4)]],
      password: ["", [Validators.required, Validators.maxLength(25), Validators.minLength(8)]],
      passwordAgain: ["", [Validators.required, Validators.maxLength(25), Validators.minLength(8)]],
    }, {
        validators: (group: AbstractControl): ValidationErrors | null => {
        let passwordFirst = group.get("password").value;
        let passwordSecond = group.get("passwordAgain").value;
        return passwordFirst === passwordSecond ? null : { notSame: true };
      }
    });
  }

  onSubmit(data: any) {
    debugger;
  }

  // hataları döner
  get validatorsErrors() {
    return this.ourform.controls;
  }

}
