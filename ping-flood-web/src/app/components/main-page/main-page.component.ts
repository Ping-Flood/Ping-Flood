import { Component, OnInit } from '@angular/core';

import { users } from '../../dummy-data/users';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  users = users;
  isSeekerMainPage = true;
  title = this.isSeekerMainPage ? "Offres" : "Demandes";

  constructor() { }

  ngOnInit() {
  }

}
