import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Track } from 'src/app/models/track.model';
import { TokenStorageService } from '../_services/token-storage.service';



const baseURL = "https://localhost:44306/api/Track"
const searchUrl = "https://localhost:44306/api/Track/id"

@Injectable({
  providedIn: 'root'
})
export class TrackService {

  constructor(private http: HttpClient,
    private token: TokenStorageService
    ) { }

  searchByName(name){
    const user = this.token.getUser();
    const headers = new HttpHeaders({
      'Authorization':'Bearer ' + user.token
    })

    return this.http.get(`${baseURL}/${name}/${user.user.idUser}`,{headers: headers});
  }
  getAllTrack(){
    const user = this.token.getUser();
    const headers = new HttpHeaders({
      'Authorization':'Bearer ' + user.token
    })
    return this.http.get(`${baseURL}`, {headers: headers});
  }
  get(id: any): Observable<Track>{
    const user = this.token.getUser();
    const headers = new HttpHeaders({
      'Authorization':'Bearer ' + user.token
    })
    return this.http.get(`${searchUrl}/${id}` , {headers: headers});
  }
  
  delete(id: any) : Observable<any> {
    const user = this.token.getUser();
    const headers = new HttpHeaders({
      'Authorization':'Bearer ' + user.token
    })
    return this.http.delete(`${baseURL}/${id}`, {headers: headers});
  }

  update(data: any): Observable<any> {
    const user = this.token.getUser();
    const headers = new HttpHeaders({
      'Authorization':'Bearer ' + user.token
    })
    return this.http.put(`${baseURL}`, data, {headers: headers});
  }

  create(data: any): Observable<any> {
    return this.http.post(`${baseURL}`, data);
  }

  
}
