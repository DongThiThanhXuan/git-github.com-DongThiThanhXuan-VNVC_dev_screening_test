using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<LotteryDetail> LotteryDetails { get; set; }
        public DbSet<LotteryResult> LotteryResults { get; set; }
        public DbSet<Msg> Messages { get; set; }
    }
}