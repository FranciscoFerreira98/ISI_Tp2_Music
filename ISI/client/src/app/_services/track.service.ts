import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Track } from 'src/app/models/track.model';

const baseURL = "https://localhost:44306/api/Track"
const searchUrl = "https://localhost:44306/api/Track/id"

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
    return this.http.get(`${searchUrl}/${id}`);
  }
  delete(id: any) : Observable<any> {
    return this.http.delete(`${baseURL}/${id}`);
  }

  update(data: any): Observable<any> {
    return this.http.put(`${baseURL}`, data);
  }

  create(data: any): Observable<any> {
    return this.http.post(`${baseURL}`, data);
  }

  
}
