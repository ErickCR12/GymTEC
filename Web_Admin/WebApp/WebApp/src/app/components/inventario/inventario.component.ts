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

  crearMaquina(serialStr: string, idEquipmentStr: string, brand: string, priceStr: string): void{
    const serialNumber = Number(serialStr);
    const idEquipment = Number(idEquipmentStr);
    const price = Number(priceStr);
    const nuevaMaquina = {serialNumber, idEquipment, brand, price} as Maquina;
    this.dataService.addMaquina(nuevaMaquina).subscribe(data => {
      if (data){
        this.getMaquinas();
      }
    });
  }

  modificarMaquina(serialStr: string, idEquipmentStr: string, brand: string, priceStr: string): void{
    const serialNumber = Number(serialStr);
    const idEquipment = Number(idEquipmentStr);
    const price = Number(priceStr);
    const maquinaModificada = {serialNumber, idEquipment, brand, price} as Maquina;
    this.dataService.updateMaquina(maquinaModificada).subscribe(data => {
        this.getMaquinas();
      });
  }

  eliminarMaquina(idStr: string): void{
    const serialNumber = Number(idStr);
    this.dataService.deleteMaquina(serialNumber).subscribe();
    this.maquinaDisp = this.maquinaDisp.filter(x => x.serialNumber !== serialNumber);

  }


}
