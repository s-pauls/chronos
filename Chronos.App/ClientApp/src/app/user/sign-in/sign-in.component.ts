import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { AuthService } from '../../service';
import { Router } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit, OnDestroy  {
  private destroy: Subject<void> = new Subject<void>();
  
  tokenForm: FormGroup;
  error = '';
  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router) {
    this.tokenForm = this.formBuilder.group({
      accessToken: new FormControl(null, [
        Validators.required
      ]),
      expiration: new FormControl('')
    });
  }

  ngOnInit(): void {
  }

  get accessToken() { return this.tokenForm.get('accessToken'); }

  get expiration() { return this.tokenForm.get('expiration'); }

  onSubmit(): void {
    if (this.tokenForm.valid) {
      this.error = null;
      this.authService.singIn(this.tokenForm.value)
        .pipe(takeUntil(this.destroy))
        .subscribe(() => {
          this.router.navigate(['/']);
        }, error => {
          this.error = error.error;
        });
    } else {
      this.tokenForm.markAllAsTouched();
    }
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
