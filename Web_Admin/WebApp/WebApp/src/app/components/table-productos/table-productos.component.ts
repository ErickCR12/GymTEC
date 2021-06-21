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

  prodDisp: Producto[] = [];

  ngOnInit(): void {
    this.getSucursales();
    this.getProductos();
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  getProductos(): void {
    this.dataService.getAllProductos().subscribe(data => this.prodDisp = data);
  }

  asociar(producto: Producto, sede): void{
    this.dataService.asociarProducto(producto, +sede).subscribe();
  }



}
