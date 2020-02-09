import { Component, OnInit } from '@angular/core';
import { users } from '../../dummy-data/users';
import { ApiService } from 'src/app/services/api.service';
import { User } from 'src/app/models/db-class';
import { ActivatedRoute, Router } from '@angular/router';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  faPlus = faPlus;
  users = users;
  isSeekerMainPage = true;
  title = this.isSeekerMainPage ? "Offres" : "Demandes";
  user:User;

  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router) {

  }

  ngOnInit() {
    this.user = history.state;
    if(this.user.id == null || this.user.id==undefined){
      try {
        this.user = JSON.parse(document.cookie.split(';')[document.cookie.split(';').length-1]) as User;
        this.getListUser();
      } catch (error) {
        this.router.navigateByUrl('login')
      }
    }else{
      this.getListUser();
    }
  }

  getListUser(){
    this.api.getListUser().subscribe(res=>{
      this.users = res as any;
    })
  }

  getTypeDescription(type: number): string {
    switch (type) {
      case 1:
        return "Bouffe";

      case 2:
        return "Bras";

      case 3:
        return "Matériaux";

      default:
        return "Autre";
    }
  }

  goToDetail(user:User){

  }

  createAlert(){

  }
}
