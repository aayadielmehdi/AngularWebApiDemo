import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'


@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:44324/api";
  readonly PhotoUrl = "https://localhost:44324/photos/";

  constructor(private http: HttpClient) { }

  getDepList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/departement');
  }

  addDepartement(val: any) {
    return this.http.post(this.APIUrl + '/departement', val);
  }

  updateDepartement(val: any) {
    return this.http.put(this.APIUrl + "/departement", val);
  }

  deleteDepartement(id: any) {
    return this.http.delete(this.APIUrl + "/departement/" + id)
  }

  getEmpList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/employee');
  }

  addEmployee(val: any) {
    return this.http.post(this.APIUrl + '/employee', val);
  }

  updateEmployee(val: any) {
    return this.http.put(this.APIUrl + "/employee", val);
  }

  deleteEmployee(id: any) {
    return this.http.delete(this.APIUrl + "/employee/" + id)
  }

  UploadPhoto(val: any) {
    return this.http.post(this.APIUrl + "/employee/SaveFile", val);
  }

  getAllDepartementNames(): Observable<any[]> {
    return this.http.get<any[]>(this.APIUrl + '/employee/GetAllDepartementNames');
  }

}
