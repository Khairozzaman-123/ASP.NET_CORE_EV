using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEV4.Models
{
    public class PatientsDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public PatientsDbContext(DbContextOptions<PatientsDbContext> options):base(options)
        {

        }
        public DbSet<Hospitals> Hospitals { get; set; }

        public DbSet<Patients> Patients { get; set; }

    }
}
