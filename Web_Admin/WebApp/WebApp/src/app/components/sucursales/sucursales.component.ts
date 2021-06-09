import { Component, OnInit } from '@angular/core';
import {Sucursal} from '../../models/sucursal';
// @ts-ignore


@Component({
  selector: 'app-sucursales',
  templateUrl: './sucursales.component.html',
  styleUrls: ['./sucursales.component.css']
})
export class SucursalesComponent implements OnInit {

  sucursalesDisp: Sucursal[] = [];
  sedeDisp: Sucursal = new Sucursal();

  constructor() { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  agregarSede(){
    console.log(this.sedeDisp);
    this.sucursalesDisp.push(this.sedeDisp);
    this.sedeDisp = new Sucursal();
  }

}
