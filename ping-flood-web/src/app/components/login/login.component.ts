import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { User } from 'src/app/models/db-class';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  username:string='';
  password:string='';

  wrongLogin=false;

  constructor(private api:ApiService, private activatedroute:ActivatedRoute, private router:Router) { }

  ngOnInit() {
  }

  connectUser(){
    let user = new User();
    user.email = this.username;
    user.password = this.password;
    this.api.login(user).subscribe(res=>{
      if(res){
        this.wrongLogin = false;
        document.cookie = JSON.stringify(res);
        alert(document.cookie)
        this.router.navigateByUrl('/main', { state: res });
      }else{
        this.wrongLogin = true;
      }
    })
  }

}
