import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service'

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() emp: any;
  EmployeeId: any;
  EmployeeName: any;
  Departement: any;
  DateOfJoining: any;
  PhotoFileName: any;
  PhotoFilePath: any;


  DepartementsList: any = [];


  ngOnInit(): void {
    this.LoadDepartementList();
  }

  LoadDepartementList() {
    this.service.getAllDepartementNames().subscribe(data => {
      this.DepartementsList = data;
      this.EmployeeId = this.emp.EmployeeId;
      this.EmployeeName = this.emp.EmployeeName;
      this.Departement = this.emp.Departement;
      this.DateOfJoining = this.emp.DateOfJoining;
      this.PhotoFileName = this.emp.PhotoFileName;
      this.PhotoFilePath = this.service.PhotoUrl + this.PhotoFileName;
    });
  }

  addEmployee() {
    var val = {
      EmployeeId: this.EmployeeId,
      EmployeeName: this.EmployeeName,
      Departement: this.Departement,
      DateOfJoining: this.DateOfJoining,
      PhotoFileName: this.PhotoFileName
    }
    this.service.addEmployee(val).subscribe(res => alert(res.toString()));
  }

  updateEmployee() {
    var val = {
      EmployeeId: this.EmployeeId,
      EmployeeName: this.EmployeeName,
      Departement: this.Departement,
      DateOfJoining: this.DateOfJoining,
      PhotoFileName: this.PhotoFileName
    }
    this.service.updateEmployee(val).subscribe(res => alert(res.toString()));
  }

  uploadPhoto(event: any) {

    // api savefile , on lui passe un body de type datarow, file.

    var file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('uploadedFile', file, file.name);
    this.service.UploadPhoto(formData).subscribe((data: any) => {
    this.PhotoFileName = data.toString();
    this.PhotoFilePath = this.service.PhotoUrl + this.PhotoFileName;
    });
  }

}
