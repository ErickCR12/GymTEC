import { Component, OnInit } from '@angular/core';
import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-copy-gym',
  templateUrl: './copy-gym.component.html',
  styleUrls: ['./copy-gym.component.css']
})
export class CopyGymComponent implements OnInit {

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
  }

  onChange(idSucursal: string): void {
    this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  copyGym(GymO: string, GymC: string): void {
    const id = +GymO;
    const idAdmin = -1;
    const name = 'default';
    const capacity = -1;
    const province = 'default';
    const canton = 'default';
    const district = 'default';
    const openingTime = '8:00 AM';
    const closingTime = '8:00 AM';
    const openingDate = '2021/01/01';
    const spaState = false;
    const storeState = false;

    const sucursal = {id, name, province, canton, district, openingDate, openingTime,
      closingTime, idAdmin, capacity, spaState, storeState} as Sucursal; //???
    console.log(sucursal);
    this.dataService.copiarGym(sucursal, +GymC).subscribe();
    this.getSucursales();
  }

}
