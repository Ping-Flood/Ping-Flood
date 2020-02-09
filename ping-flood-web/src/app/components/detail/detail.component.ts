import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/models/db-class';
import { faWindowClose, faHamburger, faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  faPlus = faPlus;
  faClose = faWindowClose;
  faHamburger=faHamburger;
  
  user:User;
  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router, private modalService: NgbModal) { }

  ngOnInit() {
    this.user = history.state;
    if(this.user.id == null || this.user.id==undefined){
      try {
        this.user = JSON.parse(document.cookie.split(';')[document.cookie.split(';').length-1]) as User;
        this.getDetail();
      } catch (error) {
        this.router.navigateByUrl('login');
      }
    }else{
      this.getDetail();
    }
    
  }

  getDetail(){
    this.activatedroute.paramMap.subscribe(params => {
      let id = params.get('id');
    });
  }

}
