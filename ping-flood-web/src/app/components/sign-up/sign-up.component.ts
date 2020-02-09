import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/db-class';
import { ApiService } from 'src/app/services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  prenom:string;
  nom:string;
  email:string;
  password:string;
  passwordConfirm:string
  address:string;
  city:string;
  secteur:any;
  isSeeker:boolean;
  isVolunteer:boolean;
  emailAlert:boolean;
  smsAlert:boolean;
  phone:number;

  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router, private cookieService:CookieService) { }

  ngOnInit() {
  }

  createUser(){
    if(this.password==this.passwordConfirm){
      let user = new User();
      user.firstname = this.prenom;
      user.lastname = this.nom;
      user.email = this.email;
      user.password = this.passwordConfirm;
      user.address = this.address;
      user.city = this.city;
      // user.sectorTypeId = (this.secteur)?this.secteur.Id:null;
      user.isSeeker = this.isSeeker;
      user.isVolonteer = this.isVolunteer;
      user.emailAlert = this.emailAlert;
      user.smsAlert = this.smsAlert;
      user.phone = this.phone;

      this.api.signup(user).subscribe(res=>{
        this.cookieService.set('user_pf', JSON.stringify(res));
        this.router.navigateByUrl('/main', { state: res });
      })
    }
  }

  stylePassword(){
    return {
      'border' : (this.passwordConfirm!=this.password)? '2px solid red': null
    };
  }

  isDisable(){
    let cond1 = this.nom!='' && this.prenom!='' && this.email!='' && this.address!='' && this.city!='' && this.secteur!='';
    let cond2 = this.password!='' && this.passwordConfirm != '' && this.passwordConfirm!=this.password;
    return cond1 && cond2;
  }

  goToLogin(){
    this.router.navigateByUrl('login');
  }

}
