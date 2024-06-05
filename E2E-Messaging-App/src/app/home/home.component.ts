import { Component } from '@angular/core';
import { HeaderComponent } from "./header/header.component";
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';

@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss',
    imports: [
        HeaderComponent,
        MatButtonModule,
        MatSidenavModule
    ]
})
export class HomeComponent {
  public showSideNav: boolean = false;

  public toggleSideNav(): void {
    this.showSideNav = !this.showSideNav;
  }

}
