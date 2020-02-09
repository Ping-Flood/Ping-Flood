import { Component, OnInit, ViewEncapsulation, OnDestroy } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { User, Demand } from 'src/app/models/db-class';
import { ActivatedRoute, Router } from '@angular/router';
import { faPlus, faWindowClose, faHamburger } from '@fortawesome/free-solid-svg-icons';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class MainPageComponent implements OnInit, OnDestroy {

  faPlus = faPlus;
  faClose = faWindowClose;
  faHamburger=faHamburger;
  // users = users;
  isSeekerMainPage = true;
  title = this.isSeekerMainPage ? "Offres" : "Demandes";
  user:User;
  demands:Demand[];

  isMenuOpen=false;
  filtreTypeDemade:number=0;
  demandsFiltered:Demand[] = [];
  

  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router, private modalService: NgbModal, private cookieService:CookieService) {
  }
  private interval;
  ngOnInit() {
    this.user = history.state;
    if(this.user && (this.user.id == null || this.user.id==undefined)){
      try {
        this.user = JSON.parse(this.cookieService.get('user_pf'));
        if(this.user.isSeeker){
          this.typeList = 1;
        }else if (this.user.isVolonteer){
          this.typeList = 2;
        }
        this.getListDemands();
      } catch (error) {
        this.router.navigateByUrl('login');
      }
    }else{
      if(this.user.isSeeker){
        this.typeList = 1;
      }else if (this.user.isVolonteer){
        this.typeList = 2;
      }
      this.getListDemands();
    }
  }

  ngOnDestroy(){
    if(!!this.interval){
      clearInterval(this.interval);
    }
  }

  getListDemands(){
    if(!!this.interval){
      clearInterval(this.interval);
    }

    this.interval = setInterval(()=>{
      this.api.getListDemands(this.typeList==2, this.typeList==1).subscribe(res=>{
        this.demands = res as any;
        this.changeFiltre();
      })
    },1000);
    
  }

  getUserName(demand: Demand): string{
    // let demandUser = demand.seeker != null ? demand.seeker : demand.volunteer;
    // return  demandUser.firstname + " " + demandUser.lastname;
    return '';
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

  changeFiltre(){
    if(this.filtreTypeDemade>0)
      this.demandsFiltered = this.demands.filter(x=>x.demandType.id==this.filtreTypeDemade);
    else
      this.demandsFiltered = [...this.demands];
  }

  demandDetail:Demand;
  typeList:number=1;
  changeType(typeList:number){
    this.typeList = typeList;
    this.getListDemands();
  }

  goToDetail(demand:Demand){
    this.demandDetail = demand;
    this.router.navigateByUrl('demand/'+demand.id, { state: this.user })
  }


  typeDemand:number;
  confirmRequired:boolean;
  expiration:string;
  modalCreateDemand:NgbModalRef;
  comment:string;
  createAlert(content){
    this.modalCreateDemand = this.modalService.open(content,{
      size: 'lg',
      backdrop: 'static',
      windowClass: 'modal-custom-lg',
      centered:true
    });
    this.typeDemand = 1;
    this.confirmRequired = false;
    this.comment='';
    this.expiration = new Date(new Date().getTime()+24*60*60*1000).toLocaleDateString("fr-CA");
  }

  confirmCreate(answer:boolean){
    if(answer){
      let demand = new Demand();
      demand.demandTypeId = this.typeDemand;
      demand.isConfirmationRequired = !!this.confirmRequired;
      demand.expiration = new Date(this.expiration);
      demand.date = new Date();
      demand.commentaire = this.comment;
      if(this.user.isSeeker && this.user.isVolonteer){
        if(this.typeList == 1){
          demand.volunteerUsersId = this.user.id;
        }
        if(this.typeList == 2){
          demand.seekerUsersId = this.user.id;
        }
      }else if(this.user.isSeeker && !this.user.isVolonteer){
        demand.seekerUsersId = this.user.id;
      }else if(!this.user.isSeeker && this.user.isVolonteer){
        demand.volunteerUsersId = this.user.id;
      }
      

      this.api.createDemand(demand).subscribe(res=>{
        console.log(res);
      })
    }

    this.modalCreateDemand.close();
  }


}
