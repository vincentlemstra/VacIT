import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JoblistingRoutingModule } from './joblisting-routing.module';
import { JoblistingListComponent } from './joblisting-list/joblisting-list.component';
import { JoblistingDetailsComponent } from './joblisting-details/joblisting-details.component';


@NgModule({
  declarations: [
    JoblistingListComponent,
    JoblistingDetailsComponent
  ],
  imports: [
    CommonModule,
    JoblistingRoutingModule
  ]
})
export class JoblistingModule { }
