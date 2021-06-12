import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  //deviceTypes: DeviceType[];
  //private dataService: DataService
  constructor() { }

  ngOnInit(): void {
    //this.getAllDeviceTypes();
  }

  getAllDeviceTypes(): void {
    //this.dataService.getAllDeviceTypes().subscribe( data => this.deviceTypes = data);
  }

  addDeviceType(name: string, description: string, warranty_months_str: string): void {
    //let warranty_months = Number(warranty_months_str);
    //let new_device_type = {name, description, warranty_months} as DeviceType;
    /**this.dataService.addDeviceType(new_device_type).subscribe(data => {
      if (data){
        this.deviceTypes.push(new_device_type);
      }
    });**/
  }

  deleteDeviceType(name: string, index: number): void {
    //this.deviceTypes.splice(index, 1);
    //this.dataService.deleteDeviceType(name).subscribe();
  }

  updateDeviceType(name: string, description: string, warranty_months_str: string): void {
    //let warranty_months = Number(warranty_months_str);
    //let updated_device_type = {name, description, warranty_months} as DeviceType;
    //this.dataService.updateDeviceType(updated_device_type).subscribe();
  }
}
