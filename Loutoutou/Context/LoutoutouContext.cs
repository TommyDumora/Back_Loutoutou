using Loutoutou.Models;
using Microsoft.EntityFrameworkCore;

namespace Loutoutou.Context;

public partial class LoutoutouContext : DbContext
{
    public LoutoutouContext(DbContextOptions<LoutoutouContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animals> Animals { get; set; }

    public virtual DbSet<UserGetAnimal> UserGetAnimal { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animals>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__animals__3213E83FA986EC26");

            entity.ToTable("animals");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('Paul')")
                .HasColumnName("name");
            entity.Property(e => e.PricePerDay).HasColumnName("price_per_day");
            entity.Property(e => e.Race)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("race");
            entity.Property(e => e.Sexe).HasColumnName("sexe");
        });

        modelBuilder.Entity<UserGetAnimal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_get__3213E83F14FCD387");

            entity.ToTable("user_get_animal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.EndingDate).HasColumnName("ending_date");
            entity.Property(e => e.StartingDate).HasColumnName("starting_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.UserGetAnimal)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_get_animal_animal");

            entity.HasOne(d => d.User).WithMany(p => p.UserGetAnimal)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_get_animal_user");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FD5136A0A");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}