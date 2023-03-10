using Microsoft.EntityFrameworkCore;
using VacIT.Models;

namespace VacIT.Data
{
    public class VacITDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VacITContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VacITContext>>()))
            {
                context.Database.EnsureCreated();

                if (!context.LoginInfo.Any())
                {
                    context.LoginInfo.AddRange(new List<LoginInfo>()
                    {
                        new LoginInfo()
                        {
                            Email = "admin@vacit.com",
                            Password = "admin",
                            Role = Role.Admin
                        },
                        new LoginInfo()
                        {
                            Email = "user@vacit.com",
                            Password = "user",
                            Role = Role.User
                        },
                        new LoginInfo()
                        {
                            Email = "employer@vacit.com",
                            Password = "employer",
                            Role = Role.Employer
                        },
                    });
                }

                    // Profiles
                    if (!context.Profiles.Any())
                {
                    context.Profiles.AddRange(new List<Profile>()
                    {
                        new Profile()
                        {
                            ProfilePicURL = "/img/profile/profile.png",
                            FirstName = "Henriette",
                            LastName = "Loughan",
                            LoginInfo = new LoginInfo() { Email = "henriette@loughan.com", Password = "password", Role = Role.User},
                            BirthDate = new DateTime(1986, 12, 25),
                            Phone = 876200208,
                            Address = "82 Shoshone Pass",
                            Zipcode = "3618ER",
                            Residence = "Santa Cruz do Sul",
                            Motivation = "dolorum eligendi quam cupiditate excepturi mollitia maiores labore  suscipit quas? Nulla",
                            CVURL = "http://testCV.com/"
                        },
                        new Profile()
                        {
                            ProfilePicURL = "/img/profile/profile.png",
                            FirstName = "Jeremie",
                            LastName = "Pocke",
                            LoginInfo = new LoginInfo() { Email = "jeremie@pocke.com", Password = "password", Role = Role.User },
                            BirthDate = new DateTime(1986, 12, 25),
                            Phone = 302334911,
                            Address = "3 Bartillon Plaza",
                            Zipcode = "6201FP",
                            Residence = "Newark",
                            Motivation = "dolorum eligendi quam cupiditate excepturi mollitia maiores labore  suscipit quas? Nulla",
                            CVURL = "http://testCV.com/"
                        },
                        new Profile()
                        {
                            ProfilePicURL = "/img/profile/profile.png",
                            FirstName = "Erma",
                            LastName = "MacCahee",
                            LoginInfo = new LoginInfo() { Email = "erma@maccahee.com", Password = "password", Role = Role.User },
                            BirthDate = new DateTime(1986, 12, 25),
                            Phone = 617531381,
                            Address = "49046 Blackbird Trail",
                            Zipcode = "3716DP",
                            Residence = "Arras",
                            Motivation = "dolorum eligendi quam cupiditate excepturi mollitia maiores labore  suscipit quas? Nulla",
                            CVURL = "http://testCV.com/"
                        }
                    });
                    context.SaveChanges();
                }

                // Employers
                if (!context.Employers.Any())
                {
                    context.Employers.AddRange(new List<Employer>()
                    {
                        new Employer()
                        {
                            LogoURL = "/img/employer/dsm.svg",
                            Name = "DSM",
                            LoginInfo = new LoginInfo() { Email = "info@dsm.com",  Password = "password", Role = Role.Employer },
                            WebsiteURL = "https://www.dsm.com/nederland/nl_NL/home.html",
                            Address = "Poststraat 1",
                            Zipcode = "6135KR",
                            Residence = "Sittard",
                            Description = "Koninklijke DSM N.V. is een wereldwijd, ‘purpose-led’ bedrijf in Gezondheid, Voeding en Bioscience dat vanuit wetenschappelijke basis de gezondheid van mens, dier en planeet verbetert. Duurzaamheid is voor ons een verantwoordelijkheid, een kernwaarde en staat centraal in alles wat we doen. Met onze producten en innovatieve oplossingen willen we het leven van mensen verbeteren. We richten ons hierbij op een goede gezondheid en gezonde, goed smakende en duurzaam geproduceerde voeding voor iedereen. Denk hierbij aan vitamines, mineralen, eiwitten, gezonde vetzuren, enzymen en andere gezonde ingrediënten die je terugvindt in voedselproducten voor mens en dier.",
                        },
                        new Employer()
                        {
                            LogoURL = "/img/employer/hostnet.png",
                            Name = "Hostnet BV",
                            LoginInfo = new LoginInfo() { Email = "info@hostnet.nl", Password = "password", Role = Role.Employer },
                            WebsiteURL = "https://www.hostnet.nl/",
                            Address = "De Ruijterkade 6",
                            Zipcode = "1013AA",
                            Residence = "Amsterdam",
                            Description = "Wij voorzien je van een passende online oplossing en buitengewone service. Op welk punt van jouw reis je je ook bevindt. Ondernemers helpen met hun online ambities, dat is onze missie. Want wij geloven dat elke ondernemer online succesvol kan zijn en kan blijven groeien."
                        },
                        new Employer()
                        {
                            LogoURL = "/img/employer/educom.png",
                            Name = "Educom",
                            LoginInfo = new LoginInfo() { Email = "info@edu-deta.com", Password = "password", Role = Role.Employer },
                            WebsiteURL = "https://edu-deta.com/",
                            Address = "D.U. Stikkerstraat 10",
                            Zipcode = "6842CW",
                            Residence = "Arnhem",
                            Description = "Educom is een professionele ICT-opleider die mensen bij- of omschoolt  tot softwareontwikkelaar. Wij begeleiden werkzoekende ICT-ers, of mensen die van de ICT hun beroep willen maken, door middel van een gedegen en vooral praktijkgericht traineeship naar een baan. "
                        },
                    });
                    context.SaveChanges();
                }

                // JobListings
                if (!context.JobListings.Any())
                {
                    context.JobListings.AddRange(new List<JobListing>()
                    {
                        new JobListing()
                        {
                            LogoURL = "/img/job_listing/windows.png",
                            Employer = context.Employers.Single(e => e.Name == "DSM"),
                            Name = "Applicatie Beheerder voor DSM Sittard",
                            Level = "Medior",
                            Date = new DateTime(2023, 1, 17),
                            Residence = "Sittard",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        },
                        new JobListing()
                        {
                            LogoURL = "/img/job_listing/linux.png",
                            Employer = context.Employers.Single(e => e.Name == "Hostnet BV"),
                            Name = "Linux Systeembeheerder voor Hostnet BV",
                            Level = "Junior",
                            Date = new DateTime(2022, 12, 25),
                            Residence = "Amsterdam",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        },
                        new JobListing()
                        {
                            LogoURL = "/img/job_listing/php.png",
                            Employer = context.Employers.Single(e => e.Name == "Educom"),
                            Name = "PHP Developer voor Educom Arnhem",
                            Level = "Medior",
                            Date = new DateTime(2023, 1, 28),
                            Residence = "Arnhem",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        },
                        new JobListing()
                        {
                            LogoURL = "/img/job_listing/csharp.png",
                            Employer = context.Employers.Single(e => e.Name == "Educom"),
                            Name = "C# Developer voor Educom Arnhem",
                            Level = "Junior",
                            Date = new DateTime(2023, 2, 5),
                            Residence = "Arnhem",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        },
                        new JobListing()
                        {
                            LogoURL = "/img/job_listing/python.png",
                            Employer = context.Employers.Single(e => e.Name == "Educom"),
                            Name = "Python Developer voor Educom Arnhem",
                            Level = "Senior",
                            Date = new DateTime(2023, 2, 10),
                            Residence = "Arnhem",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        },
                        new JobListing()
                        {
                            LogoURL = "/img/job_listing/java-script.png",
                            Employer = context.Employers.Single(e => e.Name == "DSM"),
                            Name = "JavaScript Developer voor DSM Sittard",
                            Level = "Junior",
                            Date = new DateTime(2022, 12, 18),
                            Residence = "Arnhem",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        },
                        new JobListing()
                        {
                            LogoURL = "/img/job_listing/csharp.png",
                            Employer = context.Employers.Single(e => e.Name == "Hostnet BV"),
                            Name = "C# Developer voor Hostnet BV",
                            Level = "Junior",
                            Date = new DateTime(2023, 2, 7),
                            Residence = "Arnhem",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}