using System;
using System.Collections.Generic;
using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Context;

public partial class User2Context : DbContext
{
    public User2Context()
    {
    }

    public User2Context(DbContextOptions<User2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Daystatus> Daystatuses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Eventmaterial> Eventmaterials { get; set; }

    public virtual DbSet<Eventstatus> Eventstatuses { get; set; }

    public virtual DbSet<Eventtype> Eventtypes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Materialstatus> Materialstatuses { get; set; }

    public virtual DbSet<Materialtype> Materialtypes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Staffstatus> Staffstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=45.67.56.214; Port=5454; Username=user2; Database=user2; Password=hGcLvi0i");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cabinet_pk");

            entity.ToTable("cabinet", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Daystatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("daystatus_pk");

            entity.ToTable("daystatus", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Day)
                .HasColumnType("character varying")
                .HasColumnName("day");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departments_pk");

            entity.ToTable("departments", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Supervisorid).HasColumnName("supervisorid");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.Departments)
                .HasForeignKey(d => d.Supervisorid)
                .HasConstraintName("departments_staff_fk");
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dependent", "management");

            entity.Property(e => e.Juniordepartmentid).HasColumnName("juniordepartmentid");
            entity.Property(e => e.Masterdepartmentid).HasColumnName("masterdepartmentid");

            entity.HasOne(d => d.Juniordepartment).WithMany()
                .HasForeignKey(d => d.Juniordepartmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dependent_departments_fk_1");

            entity.HasOne(d => d.Masterdepartment).WithMany()
                .HasForeignKey(d => d.Masterdepartmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dependent_departments_fk");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_pk");

            entity.ToTable("event", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Eventstatusid).HasColumnName("eventstatusid");
            entity.Property(e => e.Eventtypeid).HasColumnName("eventtypeid");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");

            entity.HasOne(d => d.Eventstatus).WithMany(p => p.Events)
                .HasForeignKey(d => d.Eventstatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_eventstatus_fk");

            entity.HasOne(d => d.Eventtype).WithMany(p => p.Events)
                .HasForeignKey(d => d.Eventtypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_eventtype_fk");
        });

        modelBuilder.Entity<Eventmaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eventmaterial_pk");

            entity.ToTable("eventmaterial", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Materialid).HasColumnName("materialid");

            entity.HasOne(d => d.Event).WithMany(p => p.Eventmaterials)
                .HasForeignKey(d => d.Eventid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventmaterial_event_fk");

            entity.HasOne(d => d.Material).WithMany(p => p.Eventmaterials)
                .HasForeignKey(d => d.Materialid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventmaterial_material_fk");
        });

        modelBuilder.Entity<Eventstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eventstatus_pk");

            entity.ToTable("eventstatus", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Eventtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eventtype_pk");

            entity.ToTable("eventtype", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_pk");

            entity.ToTable("material", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasColumnType("character varying")
                .HasColumnName("area");
            entity.Property(e => e.Author)
                .HasColumnType("character varying")
                .HasColumnName("author");
            entity.Property(e => e.Changedate).HasColumnName("changedate");
            entity.Property(e => e.Comfirmdate).HasColumnName("comfirmdate");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Typeid).HasColumnName("typeid");

            entity.HasOne(d => d.Status).WithMany(p => p.Materials)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("material_materialstatus_fk");

            entity.HasOne(d => d.Type).WithMany(p => p.Materials)
                .HasForeignKey(d => d.Typeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("material_materialtype_fk");
        });

        modelBuilder.Entity<Materialstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materialstatus_pk");

            entity.ToTable("materialstatus", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Materialtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materialtype_pk");

            entity.ToTable("materialtype", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("position_pk");

            entity.ToTable("position", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staff_pk");

            entity.ToTable("staff", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Cabinetid).HasColumnName("cabinetid");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.Cabinet).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Cabinetid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_cabinet_fk");

            entity.HasOne(d => d.Department).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_departments_fk");

            entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Positionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_position_fk");
        });

        modelBuilder.Entity<Staffstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staffstatus_pk");

            entity.ToTable("staffstatus", "management");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Staffid).HasColumnName("staffid");
            entity.Property(e => e.Statusid).HasColumnName("statusid");

            entity.HasOne(d => d.Event).WithMany(p => p.Staffstatuses)
                .HasForeignKey(d => d.Eventid)
                .HasConstraintName("staffstatus_event_fk");

            entity.HasOne(d => d.Staff).WithMany(p => p.Staffstatuses)
                .HasForeignKey(d => d.Staffid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staffstatus_staff_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Staffstatuses)
                .HasForeignKey(d => d.Statusid)
                .HasConstraintName("staffstatus_daystatus_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
