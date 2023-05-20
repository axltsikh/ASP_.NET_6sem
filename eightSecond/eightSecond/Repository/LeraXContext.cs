using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eightSecond
{
    public class LeraXContext : DbContext
    {
        public LeraXContext(DbContextOptions<LeraXContext> options) : base(options)
        {
        }

        public DbSet<LeraX> LeraXes { get; set; }
    }
}
