import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from './_services/token-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private roles: string[];
  isLoggedIn = false;
  showAdminBoard = false;
  showModeratorBoard = false;
  name: string;

  constructor(private tokenStorageService: TokenStorageService) { }

  ngOnInit() {
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

  logout() {
    this.tokenStorageService.signOut();
    window.location.reload();
  }
}