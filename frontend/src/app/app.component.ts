import { Component } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { provideHttpClient } from '@angular/common/http';
import { TeacherService } from './idk.service';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './home/home.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HomeComponent, HttpClientModule],
  providers: [TeacherService],
  // templateUrl: './app.component.html',
  template: ` <main>
    
    <section class="content">
      <app-home></app-home>
    </section>
  </main>`,
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'idk';
}
bootstrapApplication(AppComponent, {
  providers: [provideHttpClient()] 
})
