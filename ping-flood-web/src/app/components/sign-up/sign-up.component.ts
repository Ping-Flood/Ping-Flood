import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/db-class';
import { ApiService } from 'src/app/services/api.service';

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

  constructor(private api:ApiService) { }

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
      user.secteurTypeId = (this.secteur)?this.secteur.Id:null;

      this.api.signup(user).subscribe(res=>{
        console.log(res);
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

}
