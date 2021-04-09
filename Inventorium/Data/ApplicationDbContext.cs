using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NventoriumLib;

namespace Inventorium.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NventoriumLib.Application> Application { get; set; }
        public DbSet<NventoriumLib.Item> Item { get; set; }
        public DbSet<NventoriumLib.OBC> OBC { get; set; }
        public DbSet<NventoriumLib.Project> Project { get; set; }
        public DbSet<NventoriumLib.Rack> BinRack { get; set; }
        public DbSet<NventoriumLib.Bin> PartsBin { get; set; }
    }
}
