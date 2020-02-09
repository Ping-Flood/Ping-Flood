import { Component, OnInit } from '@angular/core';
import { faPlus, faWindowClose, faHamburger } from '@fortawesome/free-solid-svg-icons';
import { ApiService } from './services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from './models/db-class';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'ping-flood-web';
  faPlus = faPlus;
  faClose = faWindowClose;
  faHamburger=faHamburger;
  isMenuOpen=false;
  user:User;
  
  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router, private modalService: NgbModal){

  }

  ngOnInit(){
    this.user = history.state;
    if(this.user.id == null || this.user.id==undefined){
      try {
        this.user = JSON.parse(document.cookie.split(';')[document.cookie.split(';').length-1]) as User;
      } catch (error) {
        this.router.navigateByUrl('login');
      }
    }else{
      this.router.navigateByUrl('login');
    }
  }

  openMenu(){
    this.isMenuOpen=true;
    setTimeout(() => {
      document.getElementById('menuHamburger').focus();
    }, 0);
  }

  quitMenu(){
    this.isMenuOpen=false;
  }
}
