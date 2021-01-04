import { Component, OnInit } from '@angular/core';
import {TrackService} from '../_services/track.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Track } from 'src/app/models/track.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  currentTrack : Track = {
    idTrack: '',
    name: '',
    image: '',
    artist: '',
    album: '',
    spotifyId: '',
    spotifyUrl: ''

  }
  currentIndex = -1;
  p = 1;
  message =" ";
  constructor(
    private trackService : TrackService,
    private route: ActivatedRoute,
    private router: Router) { }
  
 
  ngOnInit(): void {
    this.getTrack(this.route.snapshot.paramMap.get('id'));
    this.message = '';
  }

  getTrack(id): void{
      this.trackService.get(id)
        .subscribe(
          data => {
            this.currentTrack = data;
            console.log(data);
          },
          error => {
            console.log(error);
          });
    }

  deleteTrack(): void {
      this.trackService.delete(this.currentTrack[0].idTrack)
        .subscribe(
          response => {
            console.log(response);
           
            this.router.navigate(['/dashboard']);
          },
          error => {
            console.log(error);
          });
   }

   updateTrack(): void {
    this.trackService.update(this.currentTrack[0])
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The tutorial was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }
  
}
