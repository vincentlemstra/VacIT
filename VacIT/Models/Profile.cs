﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public class Profile : IEntityBase
    {
        // todo restricties toevoegen
        // todo error messages toevoegen

        [Key]
        public int Id { get; set; }

        public string ProfilePicURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Residence { get; set; }
        public string Motivation { get; set; }
        public string CVURL { get; set; }

        // Relationships
        public List<JobApplication> JobApplications { get; set; }

        // Login
        public ApplicationUser ApplicationUser { get; set; }
    }
}