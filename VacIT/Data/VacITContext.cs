using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VacIT.Models;

namespace VacIT.Data
{
    public class VacITContext : DbContext
    {
        public VacITContext (DbContextOptions<VacITContext> options)
            : base(options)
        {
        }

        public DbSet<VacIT.Models.Profile> Profile { get; set; } = default!;
    }
}
