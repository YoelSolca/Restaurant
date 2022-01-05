import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Foods } from '../Models/foods';

@Injectable({
  providedIn: 'root'
})
export class FoodsService {

  private url = 'https://localhost:44329/api/foods/';

  constructor(private http: HttpClient) { }


  getList(): Observable<any> {
    return this.http.get(this.url);
  }

  get(id: number): Observable<any>{
    return this.http.get(this.url + id);
  }  

  Update(id: number, food: Foods): Observable<any>{
    return this.http.put(this.url + id, food);
  } 
  
  save(food: Foods): Observable<any>{
    return this.http.post(this.url, food);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.url + id);
  }
}
