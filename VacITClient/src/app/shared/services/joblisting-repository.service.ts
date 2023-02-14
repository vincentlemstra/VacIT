import { JobListing } from 'src/app/_interfaces/joblisting.model';
import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JoblistingRepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getJobListings = (route: string) => {
    return this.http.get<JobListing[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getJobListing = (route: string) => {
    return this.http.get<JobListing>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public createJobListing = (route: string, jobListing: JobListing) => {
    return this.http.post<JobListing>(this.createCompleteRoute(route, this.envUrl.urlAddress), jobListing, this.generateHeaders());
  }

  public updateJobListing = (route: string, jobListing: JobListing) => {
    return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), jobListing, this.generateHeaders());
  }

  public deleteJobListing = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}