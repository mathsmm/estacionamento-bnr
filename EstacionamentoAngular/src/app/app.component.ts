import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from './nav/nav.component';
// import { DashComponent } from './dash/dash.component';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    NavComponent,
    // DashComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'EstacionamentoAngular';
}
