import { Component, OnInit } from '@angular/core';
import {TrackService} from '../_services/track.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  music = {
    name: '',
    image: '',
    artist: '',
    album: '',
    spotifyId: '',
    spotifyUrl: '',
    youtubeId:'',
    youtubeUrl:''
  }

  constructor(
    private trackService : TrackService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
  }
 
  saveTrack() {
    const data = {
      name: this.music.name,
      image: this.music.image,
      artist: this.music.artist,
      album: this.music.album,
      spotifyId: this.music.spotifyId,
      spotifyUrl: this.music.spotifyUrl,
      youtubeId: this.music.youtubeId,
      youtubeUrl: this.music.youtubeUrl
    };
    this.trackService.create(data)
    .subscribe(
      response => {
        console.log(data);
        console.log(response);
        // this.router.navigate(['/dashboard']);
      },
      error => {
        console.log(error);
      });
  }
}
