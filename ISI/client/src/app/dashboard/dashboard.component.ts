import { Component, OnInit } from '@angular/core';
import {TrackService} from '../_services/track.service';
import { TokenStorageService } from '../_services/token-storage.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private trackService : TrackService,
    private tokenStorageService: TokenStorageService
    ) { }
  
  private roles: string[];
  isLoggedIn = false;
  showAdminBoard = false;
  showModeratorBoard = false;
  name: string;
  track = '';
  tracks: any
  musics = [];
  currentTrack = null;
  currentIndex = -1;
  p=1;

  ngOnInit() {
     this.getAllTrack();
      
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.roles = user.user.role;

      this.showAdminBoard = this.roles.includes('admin');
      this.showModeratorBoard = this.roles.includes('user');

      this.name = user.user.email;
      console.log(this.name);
     
    }
  }
    
    refreshList(): void {
      this.getAllTrack();
      this.currentTrack = null;
      this.currentIndex = -1;
    }
  
    setActiveTrack(trackss, index): void {
      this.currentTrack = trackss;
      this.currentIndex = index;
    }

    searchTrack(): void {
      this.trackService.searchByName(this.track)
        .subscribe(
          data => {
            this.tracks = data;
            console.log(data);
          },
          error => {
            console.log(error);
          });
    }
    getAllTrack(): void {
      this.trackService.getAllTrack()
        .subscribe(
          data => {
            this.tracks = data;
            console.log(data);
          },
          error => {
            console.log(error);
          });
    }
}