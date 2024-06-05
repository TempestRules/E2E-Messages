import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule
  ],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {

  constructor() { }
  
  public hidePassword = true;
  public hideRepeatPassword = true;

  public signUpForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    repeatPassword: new FormControl('')
  });

  public clickPassword(event: MouseEvent) {
    this.hidePassword = !this.hidePassword;
    event.stopPropagation();
  }

  public clickRepeatPassword(event: MouseEvent) {
    this.hideRepeatPassword = !this.hideRepeatPassword;
    event.stopPropagation();
  }

  public handleSubmit() {
    alert(this.signUpForm.value.username + ' | ' + this.signUpForm.value.password);
  }
}
