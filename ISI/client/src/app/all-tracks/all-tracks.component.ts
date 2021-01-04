import { Component, OnInit } from '@angular/core';
import {TrackService} from '../_services/track.service';


@Component({
  selector: 'app-all-tracks',
  templateUrl: './all-tracks.component.html',
  styleUrls: ['./all-tracks.component.css']
})
export class AllTracksComponent implements OnInit {
  
  track = '';
  tracks: any
  musics = [];
  currentTrack = null;
  currentIndex = -1;
  constructor(private trackService : TrackService) { }

  ngOnInit(): void {
    this.getAllTrack();
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
