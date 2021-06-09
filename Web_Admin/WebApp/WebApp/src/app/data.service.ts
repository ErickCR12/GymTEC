import { Injectable } from '@angular/core';
import {Observable, of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {MessageService} from './message.service';
import {Sucursal} from './models/sucursal';
import {Maquina} from './models/maquina';
import {Producto} from './models/producto';
import {Servicio} from './models/servicio';
import {Planilla} from './models/planilla';
import {Empleado} from './models/empleado';
import {Cliente} from './models/cliente';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private sucursalesUrl = 'api/gyms/';
  private maquinasUrl = 'api/machines/';
  private productosUrl = 'api/productos/';
  private tratamientosUrl = 'api/spas/';
  private serviciosUrl = 'api/services/';
  private equiposUrl = 'api/equipmentTypes/';
  private planillasUrl = 'api/payrolls/';
  private puestosUrl = 'api/positions/';
  private empleadosUrl = 'api/employees/';
  private clientesUrl = 'api/clients/';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient, private  messageService: MessageService) { }


  // ---------------------------------GESTION DE SUCURSALES-------------------------------------
  getAllSucursales(): Observable<Sucursal[]> {
    this.messageService.add('DataService: fetched Sucursals');
    return this.http.get<Sucursal[]>(this.sucursalesUrl)
      .pipe(
        catchError(this.handleError<Sucursal[]>('getAllSucursals', []))
      );
  }

  addSucursal(sucursal: Sucursal): Observable<Sucursal> {
    return this.http.post<Sucursal>(this.sucursalesUrl, sucursal, this.httpOptions).pipe(
      tap((newSucursal: Sucursal) => this.log(`added sucursal w/ name=${newSucursal.name}`)),
      catchError(this.handleError<Sucursal>('addSucursal'))
    );
  }

  updateSucursal(sucursal: Sucursal): Observable<Sucursal> {
    return this.http.put<Sucursal>(this.sucursalesUrl + sucursal.name, sucursal, this.httpOptions).pipe(
      catchError(this.handleError<Sucursal>('updateDish'))
    );
  }

  deleteSucursal(sucursalName: string): Observable<{}> {
    return this.http.delete(this.sucursalesUrl + sucursalName, this.httpOptions).pipe(
      catchError(this.handleError('deleteSucursal'))
    );
  }

  // ---------------------------------GESTION DE MAQUINAS-------------------------------------

  getAllMaquinas(): Observable<Maquina[]> {
    this.messageService.add('DataService: fetched maquinas');
    return this.http.get<Maquina[]>(this.maquinasUrl)
      .pipe(
        catchError(this.handleError<Maquina[]>('getAllMaquinas', []))
      );
  }

  addMaquina(maquina: Maquina): Observable<Maquina> {
    return this.http.post<Maquina>(this.maquinasUrl, maquina, this.httpOptions).pipe(
      tap((newMaquina: Maquina) => this.log(`added maquina w/ serial_number=${newMaquina.serialNumber}`)),
      catchError(this.handleError<Maquina>('addMaquina'))
    );
  }

  updateMaquina(maquina: Maquina): Observable<Maquina> {
    return this.http.put<Maquina>(this.maquinasUrl + maquina.serialNumber, maquina, this.httpOptions).pipe(
      catchError(this.handleError<Maquina>('updateMaquina'))
    );
  }

  deleteMaquina(maquinaSerialNumber: number): Observable<{}> {
    return this.http.delete(this.maquinasUrl + maquinaSerialNumber, this.httpOptions).pipe(
      catchError(this.handleError('deleteMaquina'))
    );
  }

  // ---------------------------------GESTION DE PRODUCTOS-------------------------------------

  getAllProductos(): Observable<Producto[]> {
    this.messageService.add('DataService: fetched productos');
    return this.http.get<Producto[]>(this.productosUrl)
      .pipe(
        catchError(this.handleError<Producto[]>('getAllProductos', []))
      );
  }

  addProducto(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.productosUrl, producto, this.httpOptions).pipe(
      tap((newProducto: Producto) => this.log(`added producto w/ barCode=${newProducto.barCode}`)),
      catchError(this.handleError<Producto>('addProducto'))
    );
  }

  updateProducto(producto: Producto): Observable<Producto> {
    return this.http.put<Producto>(this.productosUrl + producto.barCode, producto, this.httpOptions).pipe(
      catchError(this.handleError<Producto>('updateProducto'))
    );
  }

  deleteProducto(productoBarCode: number): Observable<{}> {
    return this.http.delete(this.productosUrl + productoBarCode, this.httpOptions).pipe(
      catchError(this.handleError('deleteProducto'))
    );
  }

  // ---------------------------------GESTION DE TRATAMIENTOS-------------------------------------

  getAllTratamientos(): Observable<Servicio[]> {
    this.messageService.add('DataService: fetched tratamientos');
    return this.http.get<Servicio[]>(this.tratamientosUrl)
      .pipe(
        catchError(this.handleError<Servicio[]>('getAllTratamientos', []))
      );
  }

  addTratamiento(tratamiento: Servicio): Observable<Servicio> {
    return this.http.post<Servicio>(this.tratamientosUrl, tratamiento, this.httpOptions).pipe(
      tap((newTratamiento: Servicio) => this.log(`added tratamiento w/ id=${newTratamiento.id}`)),
      catchError(this.handleError<Servicio>('addTratamiento'))
    );
  }

  updateTratamiento(tratamiento: Servicio): Observable<Servicio> {
    return this.http.put<Servicio>(this.tratamientosUrl + tratamiento.id, tratamiento, this.httpOptions).pipe(
      catchError(this.handleError<Servicio>('updateTratamiento'))
    );
  }

  deleteTratamiento(tratamientoId: number): Observable<{}> {
    return this.http.delete(this.tratamientosUrl + tratamientoId, this.httpOptions).pipe(
      catchError(this.handleError('deleteTratamiento'))
    );
  }

  // ---------------------------------GESTION DE SERVICIOS-------------------------------------

  getAllServicios(): Observable<Servicio[]> {
    this.messageService.add('DataService: fetched servicios');
    return this.http.get<Servicio[]>(this.serviciosUrl)
      .pipe(
        catchError(this.handleError<Servicio[]>('getAllServicios', []))
      );
  }

  addServicio(servicio: Servicio): Observable<Servicio> {
    return this.http.post<Servicio>(this.serviciosUrl, servicio, this.httpOptions).pipe(
      tap((newServicio: Servicio) => this.log(`added servicio w/ id=${newServicio.id}`)),
      catchError(this.handleError<Servicio>('addServicio'))
    );
  }

  updateServicio(servicio: Servicio): Observable<Servicio> {
    return this.http.put<Servicio>(this.serviciosUrl + servicio.id, servicio, this.httpOptions).pipe(
      catchError(this.handleError<Servicio>('updateServicio'))
    );
  }

  deleteServicio(servicioId: number): Observable<{}> {
    return this.http.delete(this.serviciosUrl + servicioId, this.httpOptions).pipe(
      catchError(this.handleError('deleteServicio'))
    );
  }

  // ---------------------------------GESTION DE TIPOS DE EQUIPO-------------------------------------

  getAllEquipos(): Observable<Servicio[]> {
    this.messageService.add('DataService: fetched equipos');
    return this.http.get<Servicio[]>(this.equiposUrl)
      .pipe(
        catchError(this.handleError<Servicio[]>('getAllEquipos', []))
      );
  }

  addEquipo(equipo: Servicio): Observable<Servicio> {
    return this.http.post<Servicio>(this.equiposUrl, equipo, this.httpOptions).pipe(
      tap((newEquipo: Servicio) => this.log(`added equipo w/ id=${newEquipo.id}`)),
      catchError(this.handleError<Servicio>('addEquipo'))
    );
  }

  updateEquipo(equipo: Servicio): Observable<Servicio> {
    return this.http.put<Servicio>(this.equiposUrl + equipo.id, equipo, this.httpOptions).pipe(
      catchError(this.handleError<Servicio>('updateEquipo'))
    );
  }

  deleteEquipo(equipoId: number): Observable<{}> {
    return this.http.delete(this.equiposUrl + equipoId, this.httpOptions).pipe(
      catchError(this.handleError('deleteEquipo'))
    );
  }

  // ---------------------------------GESTION DE PLANILLA-------------------------------------

  getAllPlanillas(): Observable<Planilla[]> {
    this.messageService.add('DataService: fetched planillas');
    return this.http.get<Planilla[]>(this.planillasUrl)
      .pipe(
        catchError(this.handleError<Planilla[]>('getAllPlanillas', []))
      );
  }

  addPlanilla(planilla: Planilla): Observable<Planilla> {
    return this.http.post<Planilla>(this.planillasUrl, planilla, this.httpOptions).pipe(
      tap((newPlanilla: Planilla) => this.log(`added planilla w/ id=${newPlanilla.id}`)),
      catchError(this.handleError<Planilla>('addPlanilla'))
    );
  }

  updatePlanilla(planilla: Planilla): Observable<Planilla> {
    return this.http.put<Planilla>(this.planillasUrl + planilla.id, planilla, this.httpOptions).pipe(
      catchError(this.handleError<Planilla>('updatePlanilla'))
    );
  }

  deletePlanilla(planillaId: number): Observable<{}> {
    return this.http.delete(this.planillasUrl + planillaId, this.httpOptions).pipe(
      catchError(this.handleError('deletePlanilla'))
    );
  }

  // ---------------------------------GESTION DE PUESTOS-------------------------------------

  getAllPuestos(): Observable<Servicio[]> {
    this.messageService.add('DataService: fetched puestos');
    return this.http.get<Servicio[]>(this.puestosUrl)
      .pipe(
        catchError(this.handleError<Servicio[]>('getAllPuestos', []))
      );
  }

  addPuesto(puesto: Servicio): Observable<Servicio> {
    return this.http.post<Servicio>(this.puestosUrl, puesto, this.httpOptions).pipe(
      tap((newPuesto: Servicio) => this.log(`added puesto w/ id=${newPuesto.id}`)),
      catchError(this.handleError<Servicio>('addPuesto'))
    );
  }

  updatePuesto(puesto: Servicio): Observable<Servicio> {
    return this.http.put<Servicio>(this.puestosUrl + puesto.id, puesto, this.httpOptions).pipe(
      catchError(this.handleError<Servicio>('updatePuesto'))
    );
  }

  deletePuesto(puestoId: number): Observable<{}> {
    return this.http.delete(this.puestosUrl + puestoId, this.httpOptions).pipe(
      catchError(this.handleError('deletePuesto'))
    );
  }

  // ---------------------------------GESTION DE EMPLEADOS-------------------------------------

  getAllEmpleados(): Observable<Empleado[]> {
    this.messageService.add('DataService: fetched empleados');
    return this.http.get<Empleado[]>(this.empleadosUrl)
      .pipe(
        catchError(this.handleError<Empleado[]>('getAllEmpleados', []))
      );
  }

  addEmpleado(empleado: Empleado): Observable<Empleado> {
    return this.http.post<Empleado>(this.empleadosUrl, empleado, this.httpOptions).pipe(
      tap((newEmpleado: Empleado) => this.log(`added empleado w/ id=${newEmpleado.idCard}`)),
      catchError(this.handleError<Empleado>('addEmpleado'))
    );
  }

  updateEmpleado(empleado: Empleado): Observable<Empleado> {
    return this.http.put<Empleado>(this.empleadosUrl + empleado.idCard, empleado, this.httpOptions).pipe(
      catchError(this.handleError<Empleado>('updateEmpleado'))
    );
  }

  deleteEmpleado(empleadoId: number): Observable<{}> {
    return this.http.delete(this.empleadosUrl + empleadoId, this.httpOptions).pipe(
      catchError(this.handleError('deleteEmpleado'))
    );
  }

  // ---------------------------------GESTION DE CLIENTES-------------------------------------

  getAllClientes(): Observable<Cliente[]> {
    this.messageService.add('DataService: fetched clientes');
    return this.http.get<Cliente[]>(this.clientesUrl)
      .pipe(
        catchError(this.handleError<Cliente[]>('getAllClientes', []))
      );
  }

  addCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.clientesUrl, cliente, this.httpOptions).pipe(
      tap((newCliente: Cliente) => this.log(`added cliente w/ id=${newCliente.idCard}`)),
      catchError(this.handleError<Cliente>('addCliente'))
    );
  }

  updateCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.put<Cliente>(this.clientesUrl + cliente.idCard, cliente, this.httpOptions).pipe(
      catchError(this.handleError<Cliente>('updateCliente'))
    );
  }

  deleteCliente(clienteId: number): Observable<{}> {
    return this.http.delete(this.clientesUrl + clienteId, this.httpOptions).pipe(
      catchError(this.handleError('deleteCliente'))
    );
  }






















  // getLoginCredentials(loginCred: Login): Observable<Login>
  // {
  //   return this.http.post<Login>(this.loginUrl, loginCred, this.httpOptions).pipe(
  //     tap((logCredentials: Login) => this.log(`usertype logged: ${logCredentials.userType}`)),
  //     catchError(this.handleError<Login>('getLoginCredentials'))
  //   );
  // }
  //

  // getAllContinents(): Observable<Region[]> {
  //   this.messageService.add('DataService: fetched continents');
  //   return this.http.get<Region[]>(this.regionsUrl + 'continents')
  //     .pipe(
  //       catchError(this.handleError<Region[]>('getAllContinents', []))
  //     );
  // }
  //
  // getCountriesByContinent(continent: string): Observable<Region[]> {
  //   this.messageService.add('DataService: fetched countriesByContinent');
  //   return this.http.get<Region[]>(this.regionsUrl + 'countries/' + continent)
  //     .pipe(
  //       catchError(this.handleError<Region[]>('getAllContinents', []))
  //     );
  // }
  //


  // tslint:disable-next-line:typedef
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  // tslint:disable-next-line:typedef
  private log(message: string) {
    this.messageService.add(`DataService: ${message}`);
  }


}
