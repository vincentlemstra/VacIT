import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JoblistingRoutingModule } from './joblisting-routing.module';
import { JoblistingListComponent } from './joblisting-list/joblisting-list.component';


@NgModule({
  declarations: [
    JoblistingListComponent
  ],
  imports: [
    CommonModule,
    JoblistingRoutingModule
  ]
})
export class JoblistingModule { }
