import { NgFor } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [NgFor],
  template: 
    `<ul>
      <li *ngFor="let item of data">
        <p>{{ item.firstName }} {{ item.lastName }}</p>
      </li>
    </ul>`,
  styleUrls: ['./student-list.component.scss']
})
export class StudentListComponent {
  @Input() data!: any;
}
