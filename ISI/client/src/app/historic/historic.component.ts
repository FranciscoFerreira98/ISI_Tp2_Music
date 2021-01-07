import { Component, OnInit } from '@angular/core';
import {HistoricService} from '../_services/historic.service';
import {TrackService} from '../_services/track.service';

@Component({
  selector: 'app-historic',
  templateUrl: './historic.component.html',
  styleUrls: ['./historic.component.css']
})
export class HistoricComponent implements OnInit {
  historic: any;
  date:any;
  tracks:any;
  currentHistoric = null;
  currentIndex = -1;
  simpleDate = [];
  p=1;
  x=0;
  constructor(
    private historicService : HistoricService,
    private trackService: TrackService) { }

  ngOnInit(): void {
    this.getHistoric();

    this.simpleDate= [];
    this.tracks =[];
  }

  refreshList(): void {
    this.getHistoric();
    this.currentHistoric = null;
    this.currentIndex = -1;
  }

  setActiveTrack(historics, index): void {
    this.currentHistoric = historics;
    console.log(this.currentHistoric)
    console.log(this.currentIndex)
    this.currentIndex = index;
  }

  getHistoric(): void {
    this.historicService.getAllHistoricUser()
      .subscribe(
        data => {
          this.historic = data;
          console.log(this.historic)
          var size = Object.keys(data).length;

          for (let i = 0; i < size; i++) {          
            this.trackService.get(this.historic[i].trackId)
                .subscribe(
                  data => {
                    this.tracks[i] = data;
                  },
                  error => {
                    console.log(error);
                  });
            
          
            var  date = new Date(data[i].date);
            var d = date.getDay();
            var m = date.getMonth()+1;
            var y = date.getFullYear();
            var h = date.getHours();
            var min = date.getMinutes();
            this.simpleDate[i] = (y + '-' + m + '-' + d + ' | ' + h + ':' + min);
          }
        },
        error => {
          console.log(error);
        });
  }

  deleteTrack(id): void {
    this.historicService.delete(id)
      .subscribe(
        response => {
          console.log(response);
         
          this.reloadPage();
        },
        error => {
          console.log(error);
        });
 }
 reloadPage() {
  window.location.reload();
}
 
}
