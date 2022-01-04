import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FoodsService {

  private url = 'https://localhost:44329/api/foods/';

  constructor(private http: HttpClient) { }


  getList(): Observable<any> {
    return this.http.get(this.url);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.url + id);
  }
}
