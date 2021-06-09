import { Injectable } from '@angular/core';
import {Client} from './models/client';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  public client: Client;
  public userType: string;
  public isAdmin: boolean;
  public isLogged: boolean;
  constructor() { }


}
