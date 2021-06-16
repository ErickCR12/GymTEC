import {Component, Input} from '@angular/core';
import {UsersService} from './users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'WebApp';

  // ________/No Users\______
  isReg = false;

  constructor(public usersService: UsersService) { }



  // ________/Super User\_______
  SwitchSUser() {
    this.usersService.isAdmin = !this.usersService.isAdmin;
  }

  LogSUser() {
    this.usersService.isLogged = !this.usersService.isLogged;
  }

  // ___________________/No User Tabs\______________________
  clickBack() {
    this.usersService.isLogged = false;
  }


  clickReg() {
    this.isReg = !this.isReg;
  }

}
