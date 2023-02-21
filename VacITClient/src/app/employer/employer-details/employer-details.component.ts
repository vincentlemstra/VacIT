import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployerRepositoryService } from 'src/app/shared/services/employer-repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Employer } from 'src/app/_interfaces/employer.model';

@Component({
  selector: 'app-employer-details',
  templateUrl: './employer-details.component.html',
  styleUrls: ['./employer-details.component.css']
})
export class EmployerDetailsComponent implements OnInit {
  employer: Employer | undefined;
  errorMessage: string = '';

  constructor (
    private employerRepository: EmployerRepositoryService,
    private activeRoute: ActivatedRoute,
    private errorHandler: ErrorHandlerService
  ) { }

  ngOnInit(): void {
    this.getEmployerDetails();
  }

  getEmployerDetails = () => {
    const routeParams = this.activeRoute.snapshot.paramMap;
    const id = Number(routeParams.get('employerId'))
    const apiUrl: string = `api/Emkployers/${id}`;

    this.employerRepository.getEmployer(apiUrl)
    .subscribe({
      next: (own: Employer) => this.employer = own,
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    })
  }
}
