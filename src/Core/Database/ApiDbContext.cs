namespace Core.Database
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using Core.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }

        //public virtual DbSet<PaymentResponse> PaymentResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentResponse>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK_PaymentResponse");
            });

            modelBuilder.Entity<PaymentRequest>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_PaymentRequest");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
