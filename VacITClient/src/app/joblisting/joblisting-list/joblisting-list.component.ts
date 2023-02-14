import { Component, OnInit } from '@angular/core';

import { JobListing } from 'src/app/_interfaces/joblisting.model';
import { JoblistingRepositoryService } from 'src/app/shared/services/joblisting-repository.service';

@Component({
  selector: 'app-joblisting-list',
  templateUrl: './joblisting-list.component.html',
  styleUrls: ['./joblisting-list.component.css']
})
export class JoblistingListComponent implements OnInit {
  joblistings: JobListing[];

  constructor(private repository: JoblistingRepositoryService) { }

  ngOnInit(): void {
    this.getAllJobListings();
  }

  private getAllJobListings = () => {
    const apiAddress: string = 'api/JobListings';
    this.repository.getJobListings(apiAddress).subscribe(own => {
      this.joblistings = own;
    })
  }


}
