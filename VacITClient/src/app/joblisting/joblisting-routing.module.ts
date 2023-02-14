import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JoblistingListComponent } from './joblisting-list/joblisting-list.component';

const routes: Routes = [
  { path:'list', component: JoblistingListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JoblistingRoutingModule { }
