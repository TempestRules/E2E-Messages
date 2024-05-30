import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-front',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './front.component.html',
  styleUrl: './front.component.scss'
})
export class FrontComponent {
}
