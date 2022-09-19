import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AdminModule } from './admin/admin.module';
import { UiModule } from './ui/ui.module';
import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [
    AppComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    AdminModule, UiModule,

    HttpClientModule,

    NgxSpinnerModule,
    FontAwesomeModule
  ],

  providers: [
    { provide: "baseUrl", useValue: "http://localhost:5153/api", multi: true }
  ],

  bootstrap: [AppComponent]
})

export class AppModule { }
