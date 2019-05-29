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

        public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }

        public virtual DbSet<PaymentResponse> PaymentResponses { get; set; }
    }
}
