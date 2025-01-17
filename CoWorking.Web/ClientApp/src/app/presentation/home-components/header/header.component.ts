import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isUserAuthorization: boolean;

  constructor(private authService: AuthenticationService, private router: Router) {
  }

  ngOnInit() {
    if(!this.authService.currentUser.isAuth){
      this.isUserAuthorization = true;
    }
    else{
      this.isUserAuthorization = false;
    }
  }

  logout() {
    this.authService.logout().subscribe(
      () => {
        this.ngOnInit();
        this.router.navigate(['']);
      }
    )
  }

  getRole() : string {
    return this.authService.currentUser.role;
  }

}
