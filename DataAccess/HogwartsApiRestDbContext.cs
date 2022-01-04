using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HogwartsApiRestDbContext : DbContext
    {
        public HogwartsApiRestDbContext()
        {

        }

        public HogwartsApiRestDbContext(DbContextOptions<HogwartsApiRestDbContext> options) : base(options)
        {

        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
