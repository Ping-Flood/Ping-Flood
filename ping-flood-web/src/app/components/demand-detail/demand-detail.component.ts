import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { User, Demand } from 'src/app/models/db-class';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-demand-detail',
  templateUrl: './demand-detail.component.html',
  styleUrls: ['./demand-detail.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DemandDetailComponent implements OnInit {

  demand:Demand;
  filtreTypeDemande:number=0;

  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router, private modalService: NgbModal) {

  }

  ngOnInit() {
    try {
      this.getDemand();
      // this.getListDemands();
    } catch (error) {
      this.router.navigateByUrl('login');
    }
  }


  getDemand(){
    this.activatedroute.paramMap.subscribe(params => {
      let id = params.get('id');
      this.api.getDemand(id).subscribe(res=>{
        this.demand = res;
      })
    });
  }
}
