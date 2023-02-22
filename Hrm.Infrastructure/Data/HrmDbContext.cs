using Hrm.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Infrastructure.Data
{
    public class HrmDbContext : DbContext
    {
        public HrmDbContext(DbContextOptions<HrmDbContext> options) : base(options)
        {

        }

        public DbSet<JobRequirement> JobRequirement { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
    }
}