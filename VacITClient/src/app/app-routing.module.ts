import { JoblistingListComponent } from './joblisting/joblisting-list/joblisting-list.component';
import { JoblistingDetailsComponent } from './joblisting/joblisting-details/joblisting-details.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { EmployerListComponent } from './employer/employer-list/employer-list.component';
import { EmployerDetailsComponent } from './employer/employer-details/employer-details.component';

const routes: Routes = [
  { path: '', component: JoblistingListComponent },
  { path: 'joblistings/:joblistingId', component: JoblistingDetailsComponent },
  { path: 'employers', component: EmployerListComponent },
  { path: 'employers/:employerId', component: EmployerDetailsComponent},
  { path: '404', component: NotFoundComponent },
  { path: '500', component: InternalServerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }