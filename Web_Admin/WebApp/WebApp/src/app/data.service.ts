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
import {Puesto} from './models/puesto';
import {Equipo} from './models/equipo';
import {Tratamiento} from './models/tratamiento';
import {SemanasGym} from './models/SemanasGym';
import {Login} from './models/login';
import {GeneracionPlanilla} from './models/generacionPlanilla';

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
  private gymConfigUrl = 'api/gymConfig/';
  private loginUrl = 'api/login/';

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
    return this.http.put<Sucursal>(this.sucursalesUrl + sucursal.id, sucursal, this.httpOptions).pipe(
      catchError(this.handleError<Sucursal>('updateDish'))
    );
  }

  deleteSucursal(sucursalId: number): Observable<{}> {
    return this.http.delete(this.sucursalesUrl + sucursalId, this.httpOptions).pipe(
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

  getAllTratamientos(): Observable<Tratamiento[]> {
    this.messageService.add('DataService: fetched tratamientos');
    return this.http.get<Tratamiento[]>(this.tratamientosUrl)
      .pipe(
        catchError(this.handleError<Tratamiento[]>('getAllTratamientos', []))
      );
  }

  crearTratamiento(tratamiento: Tratamiento): Observable<Servicio> {
    return this.http.post<Tratamiento>(this.tratamientosUrl, tratamiento, this.httpOptions).pipe(
      tap((newTratamiento: Tratamiento) => this.log(`added tratamiento w/ id=${newTratamiento.id}`)),
      catchError(this.handleError<Tratamiento>('addTratamiento'))
    );
  }

  updateTratamiento(tratamiento: Tratamiento): Observable<Tratamiento> {
    return this.http.put<Tratamiento>(this.tratamientosUrl + tratamiento.id, tratamiento, this.httpOptions).pipe(
      catchError(this.handleError<Tratamiento>('updateTratamiento'))
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


  crearServicio(servicio: Servicio): Observable<Servicio> {
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

  getAllEquipos(): Observable<Equipo[]> {
    this.messageService.add('DataService: fetched equipos');
    return this.http.get<Equipo[]>(this.equiposUrl)
      .pipe(
        catchError(this.handleError<Equipo[]>('getAllEquipos', []))
      );
  }

  addEquipo(equipo: Equipo): Observable<Equipo> {
    return this.http.post<Equipo>(this.equiposUrl, equipo, this.httpOptions).pipe(
      tap((newEquipo: Equipo) => this.log(`added equipo w/ id=${newEquipo.id}`)),
      catchError(this.handleError<Equipo>('addEquipo'))
    );
  }

  updateEquipo(equipo: Equipo): Observable<Equipo> {
    return this.http.put<Equipo>(this.equiposUrl + equipo.id, equipo, this.httpOptions).pipe(
      catchError(this.handleError<Equipo>('updateEquipo'))
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

  pagoMensual(sucursalId: number): Observable<GeneracionPlanilla[]> {
    this.messageService.add('DataService: fetched pagoMensual');
    return this.http.get<GeneracionPlanilla[]>(this.planillasUrl + 'generateMonthly' + sucursalId)
      .pipe(
        catchError(this.handleError<GeneracionPlanilla[]>('pagoMensual', []))
      );
  }

  pagoPorClase(sucursalId: number): Observable<GeneracionPlanilla[]> {
    this.messageService.add('DataService: fetched pagoPorClase');
    return this.http.get<GeneracionPlanilla[]>(this.planillasUrl + 'generatePerClass' + sucursalId)
      .pipe(
        catchError(this.handleError<GeneracionPlanilla[]>('pagoPorClase', []))
      );
  }

  pagoPorHora(sucursalId: number): Observable<GeneracionPlanilla[]> {
    this.messageService.add('DataService: fetched pagoPorHora');
    return this.http.get<GeneracionPlanilla[]>(this.planillasUrl + 'generatePerHour' + sucursalId)
      .pipe(
        catchError(this.handleError<GeneracionPlanilla[]>('pagoPorHora', []))
      );
  }


  // ---------------------------------GESTION DE PUESTOS-------------------------------------

  getAllPuestos(): Observable<Puesto[]> {
    this.messageService.add('DataService: fetched puestos');
    return this.http.get<Puesto[]>(this.puestosUrl)
      .pipe(
        catchError(this.handleError<Puesto[]>('getAllPuestos', []))
      );
  }

  addPuesto(puesto: Puesto): Observable<Puesto> {
    return this.http.post<Puesto>(this.puestosUrl, puesto, this.httpOptions).pipe(
      tap((newPuesto: Puesto) => this.log(`added puesto w/ id=${newPuesto.id}`)),
      catchError(this.handleError<Puesto>('addPuesto'))
    );
  }

  updatePuesto(puesto: Puesto): Observable<Puesto> {
    return this.http.put<Puesto>(this.puestosUrl + puesto.id, puesto, this.httpOptions).pipe(
      catchError(this.handleError<Puesto>('updatePuesto'))
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

  // ----------------------------CONFIGURACION DE GYM-----------------------------------

  asociarSpa(spa: Tratamiento, gymId: number): Observable<Tratamiento> {
    return this.http.post<Tratamiento>(this.gymConfigUrl + 'spaTreatments/' + gymId, spa, this.httpOptions).pipe(
      tap((newTratamiento: Tratamiento) => this.log(`added tratamiento w/ id=${newTratamiento.id}`)),
      catchError(this.handleError<Tratamiento>('asociarSpa'))
    );
  }

  asociarProducto(producto: Producto, gymId: number): Observable<Producto> {
    return this.http.post<Producto>(this.gymConfigUrl + 'products/' + gymId, producto, this.httpOptions).pipe(
      tap((newProducto: Producto) => this.log(`added producto w/ id=${newProducto.barCode}`)),
      catchError(this.handleError<Producto>('asociarProducto'))
    );
  }

  asociarMaquina(maquina: Maquina, gymId: number): Observable<Maquina> {
    return this.http.post<Maquina>(this.gymConfigUrl + 'machines/' + gymId, maquina, this.httpOptions).pipe(
      tap((newMaquina: Maquina) => this.log(`added machine w/ id=${newMaquina.serialNumber}`)),
      catchError(this.handleError<Maquina>('asociarMaquina'))
    );
  }

  copiarSemanasGym(semanas: SemanasGym, gymId: number): Observable<SemanasGym> {
    return this.http.post<SemanasGym>(this.gymConfigUrl + 'copyWeeks/' + gymId, semanas, this.httpOptions).pipe(
      tap((copiedWeeks: SemanasGym) => catchError(this.handleError<SemanasGym>('copiarSemanasGym')))
    );
  }

  copiarGym(sucursal: Sucursal, newGymId: number): Observable<Sucursal> {
    return this.http.post<Sucursal>(this.gymConfigUrl + 'copyGym/' + newGymId, sucursal, this.httpOptions).pipe(
      tap((copiedWeeks: Sucursal) => catchError(this.handleError<Sucursal>('copiarGym')))
    );
  }

  // ----------------------------LOGIN-----------------------------------

  getLoginCredentials(loginCred: Login): Observable<Login>
  {
    return this.http.post<Login>(this.loginUrl, loginCred, this.httpOptions).pipe(
      tap((logCredentials: Login) => this.log(`usertype logged: ${logCredentials.userType}`)),
      catchError(this.handleError<Login>('getLoginCredentials'))
    );
  }


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
