import { Component, EventEmitter, Output } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatIconModule,
    MatButtonModule,
    MatToolbarModule
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  @Output() 
  showSideNavEmitter = new EventEmitter<void>();

  public toggleSideNav(): void {
    this.showSideNavEmitter.emit();
  }

  public openLink(): void {
    window.open('https://youtu.be/RXKabdUBiWM?t=26', '_blank');
  }

}
