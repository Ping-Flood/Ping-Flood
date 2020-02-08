import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/db-class';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl='http://192.168.250.62:5001/api';
  constructor(private http:HttpClient) { }

  login(user:User):Observable<any>{
    return this.http.post(`${this.baseUrl}/login`, user).pipe(map(res => {
      return (<any>res).masked_databases as any;
    }));
  }
}
