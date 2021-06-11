import { Component, OnInit } from '@angular/core';
import {Maquina} from '../../models/maquina';
import {DataService} from '../../data.service';
import {Sucursal} from "../../models/sucursal";

@Component({
  selector: 'app-inventario',
  templateUrl: './inventario.component.html',
  styleUrls: ['./inventario.component.css']
})
export class InventarioComponent implements OnInit {

  maquinaDisp: Maquina[] = [];
  maquinaSleccionada = {} as Maquina;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getMaquinas();
  }

  onChange(idMaquina: string): void{
    this.maquinaSleccionada = this.maquinaDisp.find(x => x.serialNumber === Number(idMaquina));
  }

  getMaquinas(): void{
    this.dataService.getAllMaquinas().subscribe(data => this.maquinaDisp = data);
  }

  crearMaquina(serialStr: string, tipoequipo: string, brand: string, priceStr: string, sucursal: string): void{
    const serialNumber = Number(serialStr);
    const price = Number(priceStr);
    const nuevaMaquina = {serialNumber, tipoequipo, brand, price, sucursal} as Maquina;
    this.dataService.addMaquina(nuevaMaquina).subscribe();
  }

  modificarMaquina(idSelectstr: string, serialStr: string, tipoequipo: string, brand: string, priceStr: string, sucursal: string): void{
    const idSelect = Number(idSelectstr);
    const serialNumber = Number(serialStr);
    const price = Number(priceStr);
    const maquinaModificada = {idSelect, serialNumber, tipoequipo, brand, price, sucursal} as Maquina;
    this.dataService.updateMaquina(maquinaModificada).subscribe();
  }

  eliminarMaquina(idStr: string): void{
    const serialNumber = Number(idStr);
    this.dataService.deleteMaquina(serialNumber).subscribe();
  }


}
