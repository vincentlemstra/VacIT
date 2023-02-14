import { JobListing } from "./joblisting.model";

export interface Employer {
    id: string;
    logoURL: string;
    name: string;
    websiteURL: string;
    address: string;
    zipcode: string;
    residence: string;
    description: string;

    joblistings?: JobListing[];
}