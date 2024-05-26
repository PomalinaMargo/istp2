using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MachineryShop.Model;

public partial class MachineryShopContext : DbContext
{
    public MachineryShopContext()
    {
    }

    public MachineryShopContext(DbContextOptions<MachineryShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-DV20CNK\\SQLEXPRESS; Database=MachineryShop; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Categories");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
        });
        /* modelBuilder.Entity<Category>(entity =>
         {
             entity.ToTable("Category");

             entity.Property(e => e.Id).HasColumnName("id");
             entity.Property(e => e.Name).HasMaxLength(50);
         });*/

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ware");
            entity.ToTable("Device");

           // entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Devices)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Device_Category");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Order");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Device).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Deviceid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Order_Device");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Order_User");
            /* entity.ToTable("Order");

             entity.Property(e => e.Id).HasColumnName("id");

             entity.HasOne(d => d.Device).WithMany(p => p.Orders)
                 .HasForeignKey(d => d.Deviceid)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Order_Device");

             entity.HasOne(d => d.User).WithMany(p => p.Orders)
                 .HasForeignKey(d => d.Userid)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Order_User");*/
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

           // entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
