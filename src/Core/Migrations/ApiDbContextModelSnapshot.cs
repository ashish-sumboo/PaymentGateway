using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Core.Database;
using Core.Types;

namespace Core.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Card", b =>
                {
                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cvv");

                    b.Property<int>("ExpiryMonth");

                    b.Property<int>("ExpiryYear");

                    b.HasKey("Number");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Core.Entities.PaymentRequest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CardNumber");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Currency");

                    b.Property<string>("MerchantId");

                    b.HasKey("Id")
                        .HasName("PK_PaymentRequest");

                    b.HasIndex("CardNumber");

                    b.ToTable("PaymentRequest");
                });

            modelBuilder.Entity("Core.Entities.PaymentResponse", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CardNumber");

                    b.Property<string>("Currency");

                    b.Property<string>("PaymentRequestId");

                    b.Property<string>("Status");

                    b.Property<int>("StatusCode");

                    b.HasKey("Id")
                        .HasName("PK_PaymentResponse");

                    b.HasIndex("CardNumber");

                    b.ToTable("PaymentResponse");
                });

            modelBuilder.Entity("Core.Entities.PaymentRequest", b =>
                {
                    b.HasOne("Core.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardNumber");
                });

            modelBuilder.Entity("Core.Entities.PaymentResponse", b =>
                {
                    b.HasOne("Core.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardNumber");
                });
        }
    }
}
