import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {EmployeeComponent} from './employee/employee.component';
import {DepartementComponent} from './departement/departement.component';

const routes: Routes = [
  {path:'employee',component:EmployeeComponent},
  {path:'departement',component:DepartementComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
