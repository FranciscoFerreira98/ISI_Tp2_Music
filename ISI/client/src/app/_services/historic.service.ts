import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Historic } from 'src/app/models/historic.model';
import { TokenStorageService } from '../_services/token-storage.service';
import { Track } from 'src/app/models/track.model';

const baseURL = "https://isitp220210110134451.azurewebsites.net/api/Historic";
const searchUrl = "https://isitp220210110134451.azurewebsites.net/api/Track/id";


@Injectable({
  providedIn: 'root'
})
export class HistoricService {

  constructor(
    private http: HttpClient,
    private token: TokenStorageService
    ) { }

  getAllHistoricUser(): Observable<Historic>{
    const user = this.token.getUser();
    const headers = new HttpHeaders({
      'Authorization':'Bearer ' + user.token
    })
    return this.http.get(`${baseURL}/${user.user.idUser}` , {headers: headers});
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
}
