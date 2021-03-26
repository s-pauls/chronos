import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  tokenForm: FormGroup;
  error: string;
  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router) {
    this.tokenForm = this.formBuilder.group({
      accessToken: new FormControl(null, [
        Validators.required
      ]),
      expiration: new FormControl('')
    });
  }

  ngOnInit() {
  }

  get accessToken() { return this.tokenForm.get('accessToken'); }

  get expiration() { return this.tokenForm.get('expiration'); }

  onSubmit() {
    if (this.tokenForm.valid) {
      this.error = null;
      this.authService.singIn(this.tokenForm.value)
      .subscribe(() => {
        this.router.navigate(['/']);
      }, error => {
        this.error = error.error;
      });
    } else {
      this.tokenForm.markAllAsTouched();
    }
  }
}
