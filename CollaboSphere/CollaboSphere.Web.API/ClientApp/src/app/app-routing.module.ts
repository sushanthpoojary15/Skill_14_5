import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserdetailComponent } from './user/userdetail/userdetail.component';
import { AdduserComponent } from './adduser/adduser.component';
import { EdituserComponent } from './edituser/edituser.component';
import { UserStatisticsComponent } from './user-statistics/user-statistics.component';

const routes: Routes = [
  {path: 'user', 
    loadChildren: () => import('./user/user.module').then(m => m.UserModule)},
  {path:'dashboard', component: DashboardComponent},
  {path:'user-details',component:UserdetailComponent},
  {path:'add-user',component:AdduserComponent},
  {path:'edit-user',component:EdituserComponent},
  {path:'user-stastics',component:UserStatisticsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
