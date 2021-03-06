import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User, Demand, Match } from '../models/db-class';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private user:User;

  private headers:HttpHeaders = new HttpHeaders();
  private baseUrl='https://192.168.250.64:5001';
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

  getListDemand(seeker:boolean=true, volunteer:boolean=true):Observable<Demand[]>{
    return this.http.get(`${this.baseUrl}/demand/getdemandlist?isseeker=${seeker}&isvolonteer=${volunteer}`, {headers:this.headers}).pipe(map(res => {
      return (<any>res) as Demand[];
    }));
  }


  getUser(){
    return this.user;
  }

  getListDemands(isSeeker: boolean=false, isVolunteer: boolean=false):Observable<Demand[]>{
    return this.http.get(`${this.baseUrl}/demand/GetDemandList?isSeeker=${isSeeker}&isVolonteer=${isVolunteer}`, {headers:this.headers}).pipe(map(res => {
      return (<any>res) as Demand[];
    }));
  }

  getDemand(id: string):Observable<Demand>{
    return this.http.get(`${this.baseUrl}/demand/get?id=${id}`, {headers:this.headers}).pipe(map(res => {
      return (<any>res) as Demand;
    }));
  }

  createMatch(match:Match):Observable<User>{
    return this.http.post(`${this.baseUrl}/matches/create`, match, {headers:this.headers}).pipe(map(res => {
      return (<any>res) as User;
    }));
  }

}
