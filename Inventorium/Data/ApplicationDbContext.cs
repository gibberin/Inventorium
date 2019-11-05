using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InventoriumLib;

namespace Inventorium.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InventoriumLib.Application> Application { get; set; }
        public DbSet<InventoriumLib.Item> Item { get; set; }
        public DbSet<InventoriumLib.OBC> OBC { get; set; }
        public DbSet<InventoriumLib.Project> Project { get; set; }
        public DbSet<InventoriumLib.BinRack> BinRack { get; set; }
        public DbSet<InventoriumLib.PartsBin> PartsBin { get; set; }
    }
}
