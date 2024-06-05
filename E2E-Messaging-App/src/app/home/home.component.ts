import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from "./header/header.component";
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';

@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss',
    imports: [
        FormsModule,
        HeaderComponent,
        MatButtonModule,
        MatSidenavModule,
        MatInputModule,
        MatFormFieldModule,
        MatIconModule,
        MatCardModule
    ]
})
export class HomeComponent implements AfterViewInit {
  @ViewChild('scrollableMessages')
  private scrollableMessages!: ElementRef;

  public showSideNav: boolean = false;

  ngAfterViewInit(): void {
    this.scrollToBottom();
  }

  public toggleSideNav(): void {
    this.showSideNav = !this.showSideNav;
  }

  private scrollToBottom(): void {
    this.scrollableMessages.nativeElement.scrollTop = this.scrollableMessages.nativeElement.scrollHeight;
  }

  public sendMessage(): void {
    this.scrollToBottom();
  }

  public messages: string[] = [
    "Hello, how can I help you?",
    "Good morning! What can I do for you today?",
    "Welcome! Need any assistance?",
    "Hi there! How can I assist you?",
    "Hey! How's it going?",
    "Greetings! How can I be of service?",
    "Hello! Any questions I can answer for you?",
    "Hi! How can I help you out today?",
    "Good day! What can I help you with?",
    "Howdy! What can I do for you?",
    "Welcome back! How can I assist?",
    "Hello! Need help with something?",
    "Hey there! How can I support you?",
    "Hi! What do you need help with?",
    "Greetings! Need assistance?",
    "Hello! How can I be helpful today?",
    "Hi! Any assistance required?",
    "Hey! How can I aid you?",
    "Good afternoon! How can I help?",
    "Welcome! What can I assist you with?",
    "Hi! How can I assist your needs?",
    "Hey! Need any help?",
    "Good evening! What can I do for you?",
    "Hello! How can I make your day better?",
    "Hi! Do you need any help?",
    "Hey! How can I serve you today?",
    "Greetings! How can I be of help?",
    "Hello! What do you need assistance with?",
    "Hi! How can I lend a hand?",
    "Hey! How can I be of assistance today?Hey! How can I be of assistance today?Hey! How can I be of assistance today?Hey! How can I be of assistance today?"
  ];

}
