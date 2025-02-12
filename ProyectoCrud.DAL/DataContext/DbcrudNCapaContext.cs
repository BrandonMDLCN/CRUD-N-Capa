using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Models;

namespace ProyectoCrud.Datos.DataContext;

public partial class DbcrudNCapaContext : DbContext
{
    public DbcrudNCapaContext()
    {
    }

    public DbcrudNCapaContext(DbContextOptions<DbcrudNCapaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__CONTACTO__A4D6BBFA4447DB11");

            entity.ToTable("CONTACTO");

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
