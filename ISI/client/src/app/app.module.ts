import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';




import { SearchComponent } from './search/search.component';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AllTracksComponent } from './all-tracks/all-tracks.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditComponent } from './edit/edit.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { HistoricComponent } from './historic/historic.component';
import { CreateComponent } from './create/create.component';
import { CommonModule } from '@angular/common';  

@NgModule({
  declarations: [
    AllTracksComponent,
    DashboardComponent,
    EditComponent,
    RegisterComponent,
    LoginComponent,
    ProfileComponent,
    HistoricComponent,
    SearchComponent,
    CreateComponent,
    AppComponent
    

  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }