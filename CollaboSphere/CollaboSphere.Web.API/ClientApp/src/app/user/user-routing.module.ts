import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageuserComponent } from './manageuser/manageuser.component';
import { UserComponent } from './user/user.component';
import { UserdetailComponent } from './userdetail/userdetail.component';

const routes: Routes = [
  { path:'', component:UserComponent },
  { path:'userdetail/:id', component:UserdetailComponent },
  { path:'manageuser/:id', component:ManageuserComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
