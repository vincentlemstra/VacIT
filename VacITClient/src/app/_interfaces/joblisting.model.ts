import { Employer } from "./employer.model";

export interface JobListing {
    id: string;
    employerId: string;
    employer: Employer;
    logoURL: string;
    name: string;
    level: string;
    date: Date;
    residence: string;
    description: string;
}