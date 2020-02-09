import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User, Demand } from '../models/db-class';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private user:User;

  private headers:HttpHeaders = new HttpHeaders();
  private baseUrl='https://192.168.250.65:5001';
  constructor(private http:HttpClient) { 
    this.headers.append('Content-Type', 'application/json');
    this.headers = this.headers.append('X-Requested-With', 'application/json');
  }


  login(user:User):Observable<User>{
    return this.http.post(`${this.baseUrl}/user/login`, user, {headers:this.headers}).pipe(map(res => {
      this.user = res as User;
      return (<any>res) as User;
    }));
  }

  signup(user:User):Observable<User>{
    return this.http.post(`${this.baseUrl}/user/create`, user, {headers:this.headers}).pipe(map(res => {
      this.user = res as User;
      return (<any>res) as User;
    }));
  }

  getListUser():Observable<User[]>{
    return this.http.get(`${this.baseUrl}/users`, {headers:this.headers}).pipe(map(res => {
      return (<any>res) as User[];
    }));
  }

  createDemand(demand:Demand):Observable<any>{
    return this.http.post(`${this.baseUrl}/demand/create`, demand, {headers:this.headers}).pipe(map(res => {
      this.user = res as User;
      return (<any>res) as User;
    }));
  }

  getUser(){
    return this.user;
  }
}
