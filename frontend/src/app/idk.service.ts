import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  private apiUrl = 'https://localhost:7136';

  constructor(private httpClient: HttpClient) { }

  getStudentsByTeacherGuid(teacherGuid: string): Observable<any> {
    const params = new HttpParams().set('teacherGuid', teacherGuid);
    return this.httpClient.get(`${this.apiUrl}/Teacher/GetStudentsByTeacherGuid`, { params });
  }
}
