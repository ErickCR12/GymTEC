import { Component, OnInit } from '@angular/core';
//import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { NgClass } from '@angular/common';

import {DataService} from '../../data.service';
import { Cliente } from '../../models/cliente';
import { Empleado } from '../../models/empleado';
import {Region} from '../../models/region';


@Component({
  selector: 'app-register-component',
  templateUrl: './register-component.component.html',
  styleUrls: ['./register-component.component.css']
})
export class RegisterComponent implements OnInit {

  registeredClient: Cliente;
  continents: Region[];
  countries: Region[];

  constructor(private dataService: DataService) { }

  ngOnInit() {  }

  addCliente(idCar: string, email: string, password: string, name: string, last_name1: string, last_name2: string,
             birthday: string, weightStr: string, IMCstr: string, province: string, canton: string, district: string): void {
    const idCard = +idCar;
    const IMC = +IMCstr;
    const weight = +weightStr;
    const tempClient = { idCard, email, password, name, last_name1, last_name2, birthday, weight, IMC,
    province, canton, district} as Cliente;
    console.log(tempClient);
    this.dataService.addCliente(tempClient).subscribe();

  }
}
