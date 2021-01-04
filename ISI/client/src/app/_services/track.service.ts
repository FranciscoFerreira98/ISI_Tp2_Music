import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Track } from 'src/app/models/track.model';

const baseURL = "https://localhost:44306/searchTracks"
const searchById = "https://localhost:44306/searchTracksById"
const deleteTrackId= "https://localhost:44306/deleteTrack"
const UpdateTrackId= "https://localhost:44306/updateTrack"
@Injectable({
  providedIn: 'root'
})
export class TrackService {

  constructor(private http: HttpClient) { }

  searchByName(name){
    return this.http.get(`${baseURL}/${name}`);
  }
  getAllTrack(){
    return this.http.get(`${baseURL}`);
  }
  get(id: any): Observable<Track>{
    return this.http.get(`${searchById}/${id}`);
  }
  delete(id: any) : Observable<any> {
    return this.http.delete(`${deleteTrackId}/${id}`);
  }

  update(data: any): Observable<any> {
    return this.http.put(`${UpdateTrackId}`, data);
  }
}
