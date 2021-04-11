import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service'
@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() dep: any;
  DepartementId: any;
  DepartementName: any;
  

  ngOnInit(): void {    
    this.DepartementId = this.dep.DepartementId;
    this.DepartementName = this.dep.DepartementName;
  }

  addDepartement(){
    var val = {DepartementId:this.DepartementId,DepartementName:this.DepartementName}
    this.service.addDepartement(val).subscribe(res=>alert(res.toString()));
  }

  updateDepartement(){
    var val = {DepartementId:this.DepartementId,DepartementName:this.DepartementName}
    this.service.updateDepartement(val).subscribe(res=>alert(res.toString()));
  }

}
