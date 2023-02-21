import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JoblistingDetailsComponent } from './joblisting-details/joblisting-details.component';
import { JoblistingListComponent } from './joblisting-list/joblisting-list.component';

const routes: Routes = [
  { path:'list', component: JoblistingListComponent },
  { path:'details/:id', component: JoblistingDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JoblistingRoutingModule { }
