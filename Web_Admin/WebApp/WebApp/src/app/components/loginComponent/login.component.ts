import {Component, EventEmitter, Output} from '@angular/core';
import {DataService} from '../../data.service';
import {Login} from '../../models/login';
import {UsersService} from '../../users.service';
import {Cliente} from '../../models/cliente';
import {Empleado} from '../../models/empleado';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-login',
  templateUrl: './login.component.html' ,
  styleUrls: ['./login.component.css']
})
// tslint:disable-next-line:component-class-suffix
export class LoginScreen {

  constructor(private dataService: DataService, private usersService: UsersService ) { }


  checkCredentials(username: string, password: string): void{
    this.dataService.getLoginCredentials({username, password} as Login).subscribe(
      data =>
      {
        console.log(data.userType);
        switch (data.userType) {
          case 'Client':
            this.getClientByEmail(username);
            this.usersService.isAdmin = false;
            this.usersService.isLogged = true;
            break;
          case 'Invalid':
            this.usersService.isLogged = false;
            break;
          default:
            this.usersService.isAdmin = true;
            this.usersService.isLogged = true;
            break;
        }
      });
  }

  getClientByEmail(email: string): void{
    //this.dataService.getClientByEmail(email).subscribe(data => this.usersService.client = data);
  }

}
