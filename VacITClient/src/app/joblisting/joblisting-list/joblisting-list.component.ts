import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JobListing } from 'src/app/_interfaces/joblisting.model';
import { JoblistingRepositoryService } from 'src/app/shared/services/joblisting-repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-joblisting-list',
  templateUrl: './joblisting-list.component.html',
  styleUrls: ['./joblisting-list.component.css']
})
export class JoblistingListComponent implements OnInit {
  joblistings: JobListing[];
  errorMessage: string = '';

  constructor(
    private repository: JoblistingRepositoryService, 
    private errorHandler: ErrorHandlerService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllJobListings();
  }

  private getAllJobListings = () => {
    const apiAddress: string = 'api/JobListings';
    this.repository.getJobListings(apiAddress)
    .subscribe({
      next: (own: JobListing[]) => this.joblistings = own,
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    })
  }
}