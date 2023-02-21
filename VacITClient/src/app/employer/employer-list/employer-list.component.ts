import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployerRepositoryService } from 'src/app/shared/services/employer-repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Employer } from 'src/app/_interfaces/employer.model';

@Component({
  selector: 'app-employer-list',
  templateUrl: './employer-list.component.html',
  styleUrls: ['./employer-list.component.css']
})
export class EmployerListComponent implements OnInit {
  employers: Employer[];
  errorMessage: string = '';

  constructor(
    private repository: EmployerRepositoryService,
    private errorHandler: ErrorHandlerService,
    private router: Router ) { }

  ngOnInit(): void {
    this.getAllEmployers();
  }

  private getAllEmployers = () => {
    const apiAddress: string = 'api/Employers';
    this.repository.getEmployers(apiAddress)
    .subscribe({
      next: (own: Employer[]) => this.employers = own,
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    })
  }
}