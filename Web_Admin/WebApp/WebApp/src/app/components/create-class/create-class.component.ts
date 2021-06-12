import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-class',
  templateUrl: './create-class.component.html',
  styleUrls: ['./create-class.component.css']
})
export class CreateClassComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  getAllDeviceTypes(): void {
    //this.dataService.getAllDeviceTypes().subscribe( data => this.deviceTypes = data);
  }

  addDeviceType(name: string,  warranty_months_str: string): void {
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

  updateDeviceType(name: string, warranty_months_str: string): void {
    //let warranty_months = Number(warranty_months_str);
    //let updated_device_type = {name, description, warranty_months} as DeviceType;
    //this.dataService.updateDeviceType(updated_device_type).subscribe();
  }

}
