import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service'
@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service: SharedService) { }

  departementList: any = [];

  ModalTitle: any;
  ActiveAddEditDepComp: boolean = false;
  dep: any;

  DepartementFilterId: string = "";
  DepartementFilterName: string = "";
  DepartementListWithoutFilter: any = [];

  ngOnInit(): void {
    this.RefreshDepList();
  }

  RefreshDepList() {
    this.service.getDepList().subscribe(data => {
      this.departementList = data;
      this.DepartementListWithoutFilter = data;
    });
  }

  addClick() {
    this.dep = {
      DepartementId: 0,
      DepartementName: ""
    }
    this.ModalTitle = "Ajout département";
    this.ActiveAddEditDepComp = true;
  }

  closeClick() {
    this.ActiveAddEditDepComp = false;
    this.RefreshDepList();
  }

  editClick(val: any) {
    this.dep = val;
    this.ModalTitle = "Modification département";
    this.ActiveAddEditDepComp = true;
  }

  deleteClick(id: any) {
    if (confirm("etes vous sur de vouloir supprime l'enregistremenet")) {
      this.service.deleteDepartement(id).subscribe(res => {
        alert(res.toString());
        this.RefreshDepList();
      });

    }
  }

  // fonction qui permet de faire le filter 
  filterFn() {
    var departementId = this.DepartementFilterId;
    var departementName = this.DepartementFilterName;
    this.departementList = this.DepartementListWithoutFilter.filter(function (el: any) {
      return el.DepartementId.toString().toLowerCase().includes(departementId.toString().trim().toLowerCase()) &&
        el.DepartementName.toString().toLowerCase().includes(departementName.toString().trim().toLowerCase())
    });
  }

  sortResultat(colomn: string, sens: boolean) {
    // true  asc et false  desc
    // a revoir cette fonction pour le sort.
    this.departementList = this.DepartementListWithoutFilter.sort(function (a: any, b: any) {
      if (sens) {
        return (a[colomn] > b[colomn]) ? 1 : ((a[colomn] < b[colomn]) ? -1 : 0);
      } else {
        return (b[colomn] > a[colomn]) ? 1 : ((b[colomn] < a[colomn]) ? -1 : 0);
      }
    });
  }

}
