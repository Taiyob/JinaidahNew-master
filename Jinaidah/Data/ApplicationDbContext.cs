using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jinaidah.Models;

namespace Jinaidah.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Jinaidah.Models.ClientInfo> ClientInfo { get; set; }
        public DbSet<Jinaidah.Models.District> District { get; set; }
        public DbSet<Jinaidah.Models.Division> Division { get; set; }
        public DbSet<Jinaidah.Models.HoldingCategory> HoldingCategory { get; set; }
        public DbSet<Jinaidah.Models.HoldingInfo> HoldingInfo { get; set; }
        public DbSet<Jinaidah.Models.HoldingTax> HoldingTax { get; set; }
        public DbSet<Jinaidah.Models.HoldingType> HoldingType { get; set; }
        public DbSet<Jinaidah.Models.Municipility> Municipility { get; set; }
        public DbSet<Jinaidah.Models.Road> Road { get; set; }
        public DbSet<Jinaidah.Models.TaxBill> TaxBill { get; set; }
        public DbSet<Jinaidah.Models.TaxItemSetting> TaxItemSetting { get; set; }
        public DbSet<Jinaidah.Models.TaxRate> TaxRate { get; set; }
        public DbSet<Jinaidah.Models.Upzilla> Upzilla { get; set; }
        public DbSet<Jinaidah.Models.Ward> Ward { get; set; }
        public DbSet<Jinaidah.Models.WaterBill> WaterBill { get; set; }
        public DbSet<Jinaidah.Models.WaterConnection> WaterConnection { get; set; }
        public DbSet<Jinaidah.Models.WaterRate> WaterRate { get; set; }
    }
}
