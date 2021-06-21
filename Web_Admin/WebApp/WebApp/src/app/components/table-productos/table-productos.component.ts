import { Component, OnInit } from '@angular/core';
import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';
import { Producto } from '../../models/producto';

@Component({
  selector: 'app-table-productos',
  templateUrl: './table-productos.component.html',
  styleUrls: ['./table-productos.component.css']
})
export class TableProductosComponent implements OnInit {

  constructor(private dataService: DataService) { }

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  prodDisp: Producto[] = [];

  ngOnInit(): void {
    this.getSucursales();
  }

  onChange(idSucursal: string): void {
    this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  getProductos(): void {
    this.dataService.getAllProductos().subscribe(data => this.prodDisp = data);
  }

  asosciar(producto: Producto, sede): void{
    this.dataService.asociarProducto(producto, +sede).subscribe();
  }
  
  

}
