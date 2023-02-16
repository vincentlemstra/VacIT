import { Employer } from 'src/app/_interfaces/employer.model';
import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployerRepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getEmployers = (route: string) => {
    return this.http.get<Employer[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getEmployer = (route: string) => {
    return this.http.get<Employer>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  // public createEmployer = (route: string, employer: Employer) => {
  //   return this.http.post<Employer>(this.createCompleteRoute(route, this.envUrl.urlAddress), employer, this.generateHeaders());
  // }

  // public updateEmployer = (route: string, employer: Employer) => {
  //   return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), employer, this.generateHeaders());
  // }

  // public deleteEmployer = (route: string) => {
  //   return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  // }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}