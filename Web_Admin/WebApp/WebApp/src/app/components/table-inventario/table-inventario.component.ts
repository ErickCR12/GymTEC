import { Component, OnInit } from '@angular/core';
import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';
import { Maquina } from '../../models/maquina';

@Component({
  selector: 'app-table-inventario',
  templateUrl: './table-inventario.component.html',
  styleUrls: ['./table-inventario.component.css']
})
export class TableInventarioComponent implements OnInit {

  constructor(private dataService: DataService) { }

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  maquinas: Maquina[] = [];

  ngOnInit(): void {
  }

  onChange(idSucursal: string): void {
    this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }


  asosciar(maquina: Maquina, sede): void {
    this.dataService.asociarMaquina(maquina, +sede).subscribe();
  }

}
