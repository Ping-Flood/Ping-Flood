import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  prenom:string;
  nom:string;
  address:string;
  city:string;
  secteur:any;

  constructor() { }

  ngOnInit() {
  }

  createUser(){

  }

}
