import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployerRepositoryService } from 'src/app/shared/services/employer-repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { JoblistingRepositoryService } from 'src/app/shared/services/joblisting-repository.service';
import { Employer } from 'src/app/_interfaces/employer.model';
import { JobListing } from 'src/app/_interfaces/joblisting.model';

@Component({
  selector: 'app-joblisting-details',
  templateUrl: './joblisting-details.component.html',
  styleUrls: ['./joblisting-details.component.css']
})
export class JoblistingDetailsComponent implements OnInit {
  joblisting: JobListing;
  employer: Employer;
  errorMessage: string = '';

  constructor (
    private jobListingRepository: JoblistingRepositoryService, 
    private router: Router,
    private activeRoute: ActivatedRoute, 
    private errorHandler: ErrorHandlerService
  ) { }

  ngOnInit() {
    this.getJobListingDetails();
  }

  getJobListingDetails = () => {
    const id: string = this.activeRoute.snapshot.params['id'];
    const apiUrl: string = `api/JobListings/${id}`;

    this.jobListingRepository.getJobListing(apiUrl)
    .subscribe({
      next: (own: JobListing) => this.joblisting = own,
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    })
  }
}