import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { CustomvalidationService } from '../../services/customvalidation.service'
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  signUpForm: FormGroup | any;
  test: Date = new Date();
  value4: string | any;
  submitted = false;

  constructor(private fb: FormBuilder,
    private customValidator: CustomvalidationService,
    private authService: AuthService) {
    this.signUpForm = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', Validators.required],
      username: ['', [Validators.required], this.customValidator.userNameValidator.bind(this.customValidator)],
      password: ['', Validators.compose([Validators.required])],
      confirmPassword: ['', Validators.compose([Validators.required])],
      customCheckRegister: ['', Validators.required]
    },
      {
        validator: this.customValidator.MatchPassword('password', 'confirmPassword'),
      }
    );
  }
  get signupFormControl() {
    return this.signUpForm.controls;
  }

  ngOnInit(): void {
  }

  onSubmit() {
    this.submitted = true;
    if (this.signUpForm.valid) {
      this.authService.Register(this.signUpForm.value);
    }

  }
}
