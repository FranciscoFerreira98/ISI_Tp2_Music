import { Component, OnInit } from '@angular/core';
import {TrackService} from '../_services/track.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  track = '';
  tracks: any
  musics = [];
  currentTrack = null;
  currentIndex = -1;

  constructor(private trackService : TrackService) { }
 
  ngOnInit() {
   
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
