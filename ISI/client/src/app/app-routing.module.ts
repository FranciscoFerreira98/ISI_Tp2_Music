import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './search/search.component';
import {AllTracksComponent} from './all-tracks/all-tracks.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {EditComponent} from './edit/edit.component';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { HistoricComponent } from './historic/historic.component';
import {CreateComponent} from './create/create.component';


const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'alltracks', component: AllTracksComponent },
  { path: 'dashboard', component: DashboardComponent },
    { path: 'register', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'login', component: LoginComponent },
  { path: 'historic', component: HistoricComponent },
  { path: 'edit/:id', component: EditComponent },
    { path: 'create', component: CreateComponent }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
