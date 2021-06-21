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
  maquinas: Maquina[] = [];

  ngOnInit(): void {
    this.getSucursales();
    this.getMaquinas();
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  getMaquinas(): void{
    this.dataService.getAllMaquinas().subscribe(data => this.maquinas = data);
  }
  asociar(maquina: Maquina, sede): void {
    this.dataService.asociarMaquina(maquina, +sede).subscribe();
  }

}
