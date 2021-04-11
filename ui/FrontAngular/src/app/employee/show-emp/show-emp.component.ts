import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service'

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(private service:SharedService) { }

  employeeList:any = [];

  ModalTitle:any;
  ActiveAddEditEmpComp:boolean=false;
  emp:any;

  ngOnInit(): void {
    this.RefreshEmpList();
  }

  RefreshEmpList(){
    this.service.getEmpList().subscribe(data=>{
        this.employeeList=data;
    });
  }

  addClick(){
    this.emp={
      EmployeeId:0,
      EmployeeName:"",
      Departement:"",
      DateOfJoining:"",
      PhotoFileName:"none.jpg"
    }
    this.ModalTitle="Ajout employe";
    this.ActiveAddEditEmpComp=true;
  }

  closeClick(){
    this.ActiveAddEditEmpComp=false;
    this.RefreshEmpList();
  }

  editClick(val:any){
    this.emp = val;
    this.ModalTitle="Modification employe";
    this.ActiveAddEditEmpComp=true;
  }

  deleteClick(id:any){
    if(confirm("etes vous sur de vouloir supprime l'enregistremenet")){
      this.service.deleteEmployee(id).subscribe(res=>{
        alert(res.toString());
        this.RefreshEmpList();
      });
      
    }    
  }
  
}
