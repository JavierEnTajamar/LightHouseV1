using LightHouseV1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<ClaimedBy> ClaimedBys { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<RewardComposition> RewardCompositions { get; set; }
        public DbSet<RewardStatus> RewardStatuses { get; set; }
        public DbSet<RewardType> RewardTypes { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Send> Sends { get; set; }
        public DbSet<SendContent> SendContents { get; set; }
        public DbSet<Castaway> Castaways { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }

}
