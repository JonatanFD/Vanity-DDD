﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Vanity.API.Models;

namespace Vanity.API.Data;

public partial class VanityContext : DbContext
{
    public VanityContext()
    {
    }

    public VanityContext(DbContextOptions<VanityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PlanesVpn> PlanesVpns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=servervanitydb.database.windows.net;Database=VanityDB;User Id=vanityadmin;Password=Vanitydb@123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlanesVpn>(entity =>
        {
            entity.Property(e => e.PlanId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Plan).WithOne(p => p.PlanesVpn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Planes_vpn_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C42BB1B06");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
