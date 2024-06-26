using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// Использование и применение модели данных и context 
namespace BOMJ.Models;

public partial class SpravkaContext : DbContext
{
    public SpravkaContext()
    {
    }

    public SpravkaContext(DbContextOptions<SpravkaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Otdel> Otdels { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sotrud> Sotruds { get; set; }

    public virtual DbSet<User> Users { get; set; }
    //Строка подключения
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Spravka;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Otdel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Otdel__3213E83FA5ECECA4");

            entity.ToTable("Otdel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Boss)
                .HasMaxLength(100)
                .HasColumnName("boss");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Sotrud).HasColumnName("sotrud");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC070AF15AC4");

            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Sotrud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sotrud__3213E83F58D4C10C");

            entity.ToTable("Sotrud");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idotdel).HasColumnName("idotdel");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.IdotdelNavigation).WithMany(p => p.Sotruds)
                .HasForeignKey(d => d.Idotdel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sotrud__idotdel__3E52440B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0796587298");

            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__Role__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
