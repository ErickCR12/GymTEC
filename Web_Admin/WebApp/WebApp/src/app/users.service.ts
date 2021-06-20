import { Injectable } from '@angular/core';
import {Cliente} from './models/cliente';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  public client: Cliente;
  public userType: string;
  public isAdmin = false;
  public isLogged = true;
  constructor() { }


}
