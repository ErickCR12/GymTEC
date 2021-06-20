export interface Clase {
  id: number; //automatico
  idGym: number;
  idService: number;
  serviceName: string; //busqueda
  idInstructor: number;
  instructorName: string; //busqueda
  startTime: string;
  endTime: string;
  date: string;
  capacity: number;
  isGroup: boolean;
  availability: number; //Busqueda
}
