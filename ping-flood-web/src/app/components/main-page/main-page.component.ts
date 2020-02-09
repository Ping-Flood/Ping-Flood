import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { User, Demand } from 'src/app/models/db-class';
import { ActivatedRoute, Router } from '@angular/router';
import { faPlus, faWindowClose } from '@fortawesome/free-solid-svg-icons';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  faPlus = faPlus;
  faClose = faWindowClose;
  isSeekerMainPage = true;
  title = this.isSeekerMainPage ? "Offres" : "Demandes";
  user:User;
  demands:Demand[];

  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router, private modalService: NgbModal) {

  }

  ngOnInit() {
    this.user = history.state;
    if(this.user.id == null || this.user.id==undefined){
      try {
        this.user = JSON.parse(document.cookie.split(';')[document.cookie.split(';').length-1]) as User;
        this.getListDemands();
      } catch (error) {
        this.router.navigateByUrl('login')
      }
    }else{
      this.getListDemands();
    }
  }

  getListDemands(){
    this.api.getListDemands(this.user.isSeeker, this.user.isVolunteer).subscribe(res=>{
      this.demands = res as any;
    })
  }

  getUserName(demand: Demand): string{
    let demandUser = demand.seeker != null ? demand.seeker : demand.volunteer;
    return  demandUser.firstname + " " + demandUser.lastname;
  }

  getDate(demand): string{
    demand.date
    return "";
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

  goToDetail(demand:Demand){

  }


  typeDemand:number;
  confirmRequired:boolean;
  expiration:string;
  modalCreateDemand:NgbModalRef;
  createAlert(content){
    this.modalCreateDemand = this.modalService.open(content,{
      size: 'sm',
      backdrop: 'static',
      centered:true
    });
    this.typeDemand = 1;
    this.confirmRequired = false;
    this.expiration = new Date(new Date().getTime()+24*60*60*1000).toLocaleString();
  }

  confirmCreate(answer:boolean){
    if(answer){
      let demand = new Demand();
      demand.demandTypeId = this.typeDemand;
      demand.isConfirmationRequired = this.confirmRequired;
      demand.expiration = new Date(this.expiration);
      demand.date = new Date();
      if(this.typeDemand == 1){
        demand.seekerUserId = this.user.id;
      }
      if(this.typeDemand == 2){
        demand.volunteerUserId = this.user.id;
      }

      this.api.createDemand(demand).subscribe(res=>{
        console.log(res);
      })
    }

    this.modalCreateDemand.close();
  }
}
