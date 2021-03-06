import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { FormsModule } from '@angular/forms';
import { UiSwitchModule } from 'ngx-ui-switch';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DetailComponent } from './components/detail/detail.component';
import { DemandDetailComponent } from './components/demand-detail/demand-detail.component';
import { CookieService } from 'ngx-cookie-service'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    MainPageComponent,
    DetailComponent,
    DemandDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    FontAwesomeModule,
    UiSwitchModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
