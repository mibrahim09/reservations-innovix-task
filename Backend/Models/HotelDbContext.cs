using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotelsManager.Models
{
    public partial class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<MealRate> MealRates { get; set; }
        public virtual DbSet<RoomRate> RoomRates { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("meals");

                entity.Property(e => e.MealId)
                    .ValueGeneratedNever()
                    .HasColumnName("meal_id");

                entity.Property(e => e.MealType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("meal_type");
            });

            modelBuilder.Entity<MealRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meal_rates");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.MealId).HasColumnName("meal_id");

                entity.Property(e => e.RatePerPerson)
                    .HasColumnType("int")
                    .HasColumnName("rate_per_person");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Meal)
                    .WithMany()
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meal_rates_id");
            });

            modelBuilder.Entity<RoomRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("room_rates");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.RatePerRoom)
                    .HasColumnType("int")
                    .HasColumnName("rate_per_room");

                entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_type");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("room_types");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.RoomType1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("room_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
