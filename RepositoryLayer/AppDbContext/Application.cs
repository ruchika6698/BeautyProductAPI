using CommanLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.AppDbContext
{

    public class Application : DbContext
    {
        public Application(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RegisterModel> Users { get; set; }

    }

}
