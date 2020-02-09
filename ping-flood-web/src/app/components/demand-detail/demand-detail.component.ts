import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { User, Demand, Match } from 'src/app/models/db-class';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-demand-detail',
  templateUrl: './demand-detail.component.html',
  styleUrls: ['./demand-detail.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DemandDetailComponent implements OnInit {

  demand:Demand=new Demand();
  filtreTypeDemande:number=0;
  user:User;

  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router, private modalService: NgbModal, private cookieService:CookieService) {

  }

  ngOnInit() {
    this.user = history.state;
    if(this.user.id == null || this.user.id==undefined){
      try {
        this.user = JSON.parse(this.cookieService.get('user_pf')) as User;
        this.getDemand();
      } catch (error) {
        this.router.navigateByUrl('login');
      }
    }else{
      this.getDemand();
    }
  }


  getDemand(){
    this.activatedroute.paramMap.subscribe(params => {
      let id = params.get('id');
      this.api.getDemand(id).subscribe(res=>{
        this.demand = res;
        this.demand.expiration = new Date(this.demand.expiration).toLocaleDateString('fr-CA');
      })
    });
  }

  userDisplay:User;
  aider(content){
    let match:Match = new Match();
    match.demandsId = this.demand.id;
    if(this.demand.seekerUsersId>0){
      match.seekerUsersId = this.demand.seekerUsersId;
      match.volunteerUsersId = this.user.id;
    }else if(this.demand.volunteerUsersId>0){
      match.volunteerUsersId = this.demand.volunteerUsersId;
      match.seekerUsersId = this.user.id;
    }
    match.date = new Date();

    this.api.createMatch(match).subscribe(res=>{
      console.log(res);
      this.userDisplay = res;
    },err=>{

    },()=>{
      // this.router.navigateByUrl('main', {state: this.user});
      this.modalService.open(content, {
        size: 'sm',
        centered:true,
        backdrop:true
      });
    })
  }
}
