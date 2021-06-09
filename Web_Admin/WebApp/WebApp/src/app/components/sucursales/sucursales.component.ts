import { Component, OnInit } from '@angular/core';
import {Sucursal} from '../../models/sucursal';
import {DataService} from '../../data.service';
// @ts-ignore


@Component({
  selector: 'app-sucursales',
  templateUrl: './sucursales.component.html',
  styleUrls: ['./sucursales.component.css']
})
export class SucursalesComponent implements OnInit {

  sucursalesDisp: Sucursal[] = [];
  sedeDisp: Sucursal = new Sucursal();

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
  }

  getSucursales(): void{
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
}

  // tslint:disable-next-line:typedef
  agregarSede(){
    console.log(this.sedeDisp);
    this.sucursalesDisp.push(this.sedeDisp);
    this.sedeDisp = new Sucursal();
  }

}
