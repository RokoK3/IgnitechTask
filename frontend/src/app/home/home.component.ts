import { StudentListComponent } from '../student-list/student-list.component';
import { TeacherService } from './../idk.service';
import { ChangeDetectorRef, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    StudentListComponent,
    HttpClientModule,
  ], 
  template: `
    <section>
      <form>
        <label for="teacherID">Teacher ID</label>
        <input
          type="text"
          placeholder="Filter by teacher"
          [(ngModel)]="teacherID"
          [ngModelOptions]="{ standalone: true }"
        />
        <button class="primary" type="button" (click)="getTeacherService()">
          Search
        </button>
      </form>
      <div class="results">
        <app-student-list [data]="data"></app-student-list>
      </div>
    </section>
  `,
  styleUrls: ['./home.component.scss'],
  providers: [TeacherService], 
})
export class HomeComponent {
  teacherID: string = '';
  data: any;

  constructor(private teacherService: TeacherService, private cdref: ChangeDetectorRef) {}

  getTeacherService() {
    this.teacherService.getStudentsByTeacherGuid(this.teacherID).subscribe(
      (data) => {
        this.data = data;
        this.cdref.detectChanges();
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }
}
