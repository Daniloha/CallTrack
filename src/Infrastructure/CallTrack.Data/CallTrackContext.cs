using CallTrack.Data.entities;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Data;

public class CallTrackContext : DbContext
{
    public CallTrackContext(DbContextOptions<CallTrackContext> options)
        : base(options) { }

        public DbSet<Calls> Calls { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Analyst> Analysts { get; set; }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<Reasons> Reasons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(CallTrackContext)
            .Assembly);
    }

}
