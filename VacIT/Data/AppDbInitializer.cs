using Microsoft.EntityFrameworkCore;
using VacIT.Models;

namespace VacIT.Data
{
    public class AppDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VacITContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VacITContext>>()))
            {
                context.Database.EnsureCreated();

                // Profiles
                if (!context.Profiles.Any())
                {
                    context.Profiles.AddRange(new List<Profile>()
                    {
                        new Profile()
                        {
                            ProfilePicURL = "http://dummyimage.com/210x100.png/5fa2dd/ffffff",
                            FirstName = "Henriette",
                            LastName = "Loughan",
                            Email = "henriette@loughan.com",
                            Password = "password",
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
                            ProfilePicURL = "http://dummyimage.com/210x100.png/5fa2dd/ffffff",
                            FirstName = "Jeremie",
                            LastName = "Pocke",
                            Email = "jeremie@pocke.com",
                            Password = "password",
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
                            ProfilePicURL = "http://dummyimage.com/210x100.png/5fa2dd/ffffff",
                            FirstName = "Erma",
                            LastName = "MacCahee",
                            Email = "erma@maccahee.com",
                            Password = "password",
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
                            LogoURL = "http://dummyimage.com/210x100.png/5fa2dd/ffffff",
                            Name = "DSM",
                            Password = "password",
                            WebsiteURL = "https://www.dsm.com/nederland/nl_NL/home.html",
                            Address = "Poststraat 1",
                            Zipcode = "6135KR",
                            Residence = "Sittard",
                            Description = "Koninklijke DSM N.V. is een wereldwijd, ‘purpose-led’ bedrijf in Gezondheid, Voeding en Bioscience dat vanuit wetenschappelijke basis de gezondheid van mens, dier en planeet verbetert. Duurzaamheid is voor ons een verantwoordelijkheid, een kernwaarde en staat centraal in alles wat we doen. Met onze producten en innovatieve oplossingen willen we het leven van mensen verbeteren. We richten ons hierbij op een goede gezondheid en gezonde, goed smakende en duurzaam geproduceerde voeding voor iedereen. Denk hierbij aan vitamines, mineralen, eiwitten, gezonde vetzuren, enzymen en andere gezonde ingrediënten die je terugvindt in voedselproducten voor mens en dier.",

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
                            EmployerId = 1,
                            Name = "Applicatie Beheerder voor DSM Sittard",
                            Level = "Medior",
                            Date = DateTime.Today,
                            Residence = "Sittard",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed metus mi, rutrum vel accumsan fringilla, maximus at nisl. Suspendisse id nibh at arcu pulvinar posuere eu at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris pulvinar lobortis ligula quis dictum. Curabitur eu felis venenatis, dignissim lorem in, pellentesque mi. Aliquam quis ipsum id lacus accumsan vehicula. Pellentesque feugiat hendrerit dui et bibendum. Vestibulum erat risus, porttitor vel pretium at, molestie eu arcu. Donec nec placerat nulla. Ut sit amet tincidunt lectus. Vivamus condimentum sodales sem ac vehicula.\r\n\r\nSed laoreet diam sit amet dolor malesuada, eget aliquet quam feugiat. Aenean sit amet elementum lorem. Vivamus mollis dui nisi, vitae laoreet urna mollis nec. Sed fringilla imperdiet maximus. Cras vel tellus risus. Donec vel eros a mi tincidunt tristique sit amet id orci. Duis auctor diam nisl, et consequat est ornare eget. Ut blandit gravida massa, ut sagittis quam consequat et. Sed accumsan diam id ipsum auctor, non consectetur nisl cursus. Morbi dapibus ac nulla nec condimentum. Donec eu pulvinar sapien, et interdum libero. Morbi dictum sapien cursus nunc faucibus tincidunt. Vivamus vulputate dignissim eros, sit amet rhoncus orci gravida sed. Duis eget tellus sed elit cursus accumsan.\r\n\r\nCurabitur magna justo, rutrum vitae elementum quis, sodales sit amet nibh. Proin lectus ante, auctor vel nibh nec, aliquam congue ante. Suspendisse vulputate finibus turpis sit amet semper. Vestibulum lacinia erat eu orci venenatis semper. Maecenas sagittis facilisis urna. Nam pellentesque nibh pharetra, tempor sapien a, egestas nisi. Curabitur tempor molestie felis viverra accumsan.",
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
