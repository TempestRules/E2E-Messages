import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AbstractControl, AsyncValidatorFn, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { OpenPGPService } from '../../services/open-pgp/open-pgp.service';
import { KeyPair } from '../../services/open-pgp/models/keypair';
import { AccountService } from '../../services/account/account.service';
import { HttpErrorResponse } from '@angular/common/http';
import { of } from 'rxjs/internal/observable/of';
import { Observable } from 'rxjs/internal/Observable';
import { catchError, map } from 'rxjs/operators';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    ReactiveFormsModule,
    NgIf,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {

  constructor(
    private accountService: AccountService,
    private openPgpService: OpenPGPService) { }

  public hidePassword = true;
  public hideRepeatPassword = true;
  public isLoading = false;

  public signUpForm = new FormGroup({
    username: new FormControl('', {
      validators: [Validators.required],
      asyncValidators: [this.usernameValidator()],
      updateOn: 'blur'
    }),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(25),
      this.passwordLetterComplexityValidator,
      this.passwordSpecialCharsComplexityValidator
    ]),
    repeatPassword: new FormControl('', [Validators.required])
  }, { validators: this.passwordsMatchValidator });

  public clickPassword(event: MouseEvent) {
    this.hidePassword = !this.hidePassword;
    event.stopPropagation();
  }

  public clickRepeatPassword(event: MouseEvent) {
    this.hideRepeatPassword = !this.hideRepeatPassword;
    event.stopPropagation();
  }

  public async handleSubmit() {
    if (!this.signUpForm.valid) {
      this.signUpForm.markAllAsTouched;
      return;
    }

    this.isLoading = true;

    const keyPair: KeyPair = await this.openPgpService.generateKeyPair(
      this.signUpForm.value.username!,
      this.signUpForm.value.password!
    );

    this.accountService.registerAccount({
      username: this.signUpForm.value.username!,
      password: this.signUpForm.value.password!,
      publicKey: keyPair.publicKey,
      privateKey: keyPair.privateKey
    }).subscribe({
      next: (jwtResponse: string) => {
        console.log(jwtResponse);
        this.isLoading = false;
      },
      error: (error: HttpErrorResponse) => {
        // Display the error message to the user
        if (error.status === 400 && error.error instanceof Array) {
          alert(error.error[0].code + " and " + error.error[0].description);
        } else {
          alert(error.error.code + " and " + error.error.description)
        }
      },
      complete: () => {
        console.log('Registration request completed');
      }
    });
  }

  private usernameValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if (!control.value) {
        return of(null);
      }
  
      return this.accountService.checkUsername(control.value).pipe(
        map(isTaken => (isTaken ? { usernameTaken: true } : null)),
        catchError(() => of(null)) // In case of an error, treat it as valid
      );
    };
  }

  private passwordLetterComplexityValidator(control: AbstractControl): ValidationErrors | null {
    const value = control.value || '';
    
    const hasUpperCase = /[A-Z]/.test(value);
    const hasLowerCase = /[a-z]/.test(value);

    const passwordValid = hasUpperCase && hasLowerCase;
    
    return passwordValid ? null : { passwordLetterComplexity: true };
  }

  private passwordSpecialCharsComplexityValidator(control: AbstractControl): ValidationErrors | null {
    const value = control.value || '';
    
    const hasDigit = /\d/.test(value);
    const hasNonAlphanumeric = /[^a-zA-Z0-9]/.test(value);

    const passwordValid = hasDigit && hasNonAlphanumeric;
    
    return passwordValid ? null : { passwordSpecialComplexity: true };
  }

  private passwordsMatchValidator(group: AbstractControl): ValidationErrors | null {
    const password = group.get('password')?.value;
    const repeatPassword = group.get('repeatPassword')?.value;

    return password === repeatPassword ? null : { passwordsMismatch: true };
  }
}
