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
    const sucursal = { id } as Sucursal; //???
    this.dataService.copiarGym(sucursal, +GymC).subscribe();
    this.getSucursales();
  }

}
