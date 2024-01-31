using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shared.ORM.Entities;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bu> Bus { get; set; }

    public virtual DbSet<CalibrationType> CalibrationTypes { get; set; }

    public virtual DbSet<Cause> Causes { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<CostCenter> CostCenters { get; set; }

    public virtual DbSet<CostType> CostTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MachineGroup> MachineGroups { get; set; }

    public virtual DbSet<MachineStatus> MachineStatuses { get; set; }

    public virtual DbSet<MachineType> MachineTypes { get; set; }

    public virtual DbSet<MaintenanceFormal> MaintenanceFormals { get; set; }

    public virtual DbSet<MaintenanceSystem> MaintenanceSystems { get; set; }

    public virtual DbSet<MaintenanceType> MaintenanceTypes { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<Param> Params { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Problem> Problems { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Slgireason> Slgireasons { get; set; }

    public virtual DbSet<Slgrreason> Slgrreasons { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WorkerLevel> WorkerLevels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.16.128.17;Database=GFMaintenanceFeed;User Id=devops_maint;Password=cQ$Ub@jef@%FLG8z;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bu>(entity =>
        {
            entity.ToTable("BU");

            entity.Property(e => e.Buid).HasColumnName("BUId");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Bucode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("BUCode");
            entity.Property(e => e.Buname)
                .HasMaxLength(250)
                .HasColumnName("BUName");
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IndustryId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Industry).WithMany(p => p.Bus)
                .HasForeignKey(d => d.IndustryId)
                .HasConstraintName("FK_BU_Industry");
        });

        modelBuilder.Entity<CalibrationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Calibrat__3214EC07FBDE638B");

            entity.ToTable("CalibrationType");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TypeName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Param).WithMany(p => p.CalibrationTypes)
                .HasForeignKey(d => d.ParamId)
                .HasConstraintName("FK__Calibrati__Param__2CBDA3B5");
        });

        modelBuilder.Entity<Cause>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cause__3214EC0702B090D8");

            entity.ToTable("Cause");

            entity.Property(e => e.CauseName).HasMaxLength(250);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC072E560F6E");

            entity.ToTable("Class");

            entity.Property(e => e.ClassName).HasMaxLength(250);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CostCenter>(entity =>
        {
            entity.ToTable("CostCenter");

            entity.Property(e => e.CostCenterCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CostCenterName).HasMaxLength(250);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.SapDesc).HasMaxLength(250);
            entity.Property(e => e.SapName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Location).WithMany(p => p.CostCenters)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CostCenter_Location");
        });

        modelBuilder.Entity<CostType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CostType__3214EC07383F50B5");

            entity.ToTable("CostType");

            entity.Property(e => e.CostTypeName).HasMaxLength(250);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC0787B2F22B");

            entity.ToTable("Country");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CountryName).HasMaxLength(100);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC072E71A763");

            entity.ToTable("Document");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DocumentName).HasMaxLength(250);
            entity.Property(e => e.FileName).HasMaxLength(250);
            entity.Property(e => e.FilePath).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11FF5D2D1B");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Buid).HasColumnName("BUId");
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EmployeeName).HasMaxLength(250);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__RoleId__45BE5BA9");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.ToTable("Industry");

            entity.Property(e => e.IndustryId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IndustryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job__3214EC07E38F4B3B");

            entity.ToTable("Job");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Curency).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.DocPath).HasMaxLength(250);
            entity.Property(e => e.Doing).HasMaxLength(2000);
            entity.Property(e => e.JobKey).HasMaxLength(100);
            entity.Property(e => e.JobSign).HasMaxLength(100);
            entity.Property(e => e.MachineTypeId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Note).HasMaxLength(2000);
            entity.Property(e => e.PersonRequire).HasMaxLength(1000);
            entity.Property(e => e.TechStandar).HasMaxLength(1000);
            entity.Property(e => e.ToolRequire).HasMaxLength(1000);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobTypeId)
                .HasConstraintName("FK__Job__JobTypeId__0A688BB1");

            entity.HasOne(d => d.MachineType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.MachineTypeId)
                .HasConstraintName("FK__Job__MachineType__0B5CAFEA");

            entity.HasOne(d => d.Major).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.MajorId)
                .HasConstraintName("FK__Job__MajorId__0C50D423");

            entity.HasOne(d => d.Priority).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("FK__Job__PriorityId__0E391C95");

            entity.HasOne(d => d.WorkerLevel).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.WorkerLevelId)
                .HasConstraintName("FK__Job__WorkerLevel__0D44F85C");
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobType__3214EC07082CB476");

            entity.ToTable("JobType");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.JobTypeName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IndustryId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LocationCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LocationName).HasMaxLength(200);
            entity.Property(e => e.Note).HasMaxLength(200);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Industry).WithMany(p => p.Locations)
                .HasForeignKey(d => d.IndustryId)
                .HasConstraintName("FK_Location_Industry");
        });

        modelBuilder.Entity<MachineGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MachineG__3214EC07BDAE6B1F");

            entity.ToTable("MachineGroup");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MachineGroupName).HasMaxLength(150);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MachineStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MachineS__3214EC078E93844B");

            entity.ToTable("MachineStatus");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MachineStatusName).HasMaxLength(150);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MachineType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MachineT__3214EC0763E61045");

            entity.ToTable("MachineType");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MachineTypeName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MaintenanceFormal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC0793850161");

            entity.ToTable("MaintenanceFormal");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FormName).HasMaxLength(100);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MaintenanceSystem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC07D1794779");

            entity.ToTable("MaintenanceSystem");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DocPath).HasMaxLength(250);
            entity.Property(e => e.Note).HasMaxLength(2000);
            entity.Property(e => e.SystemKey).HasMaxLength(50);
            entity.Property(e => e.SystemName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MaintenanceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC07292934D7");

            entity.ToTable("MaintenanceType");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TypeName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.JobType).WithMany(p => p.MaintenanceTypes)
                .HasForeignKey(d => d.JobTypeId)
                .HasConstraintName("FK__Maintenan__JobTy__214BF109");

            entity.HasOne(d => d.MaintenanceForm).WithMany(p => p.MaintenanceTypes)
                .HasForeignKey(d => d.MaintenanceFormId)
                .HasConstraintName("FK__Maintenan__Maint__2057CCD0");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Major__3214EC0766BCF418");

            entity.ToTable("Major");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MajorName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3214EC0798A0204F");

            entity.ToTable("Material");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Acc).HasMaxLength(50);
            entity.Property(e => e.AccDescription).HasMaxLength(150);
            entity.Property(e => e.CreateBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Doc).HasMaxLength(250);
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Image2).HasMaxLength(250);
            entity.Property(e => e.IsSap).HasColumnName("IsSAP");
            entity.Property(e => e.IsSol).HasColumnName("IsSOL");
            entity.Property(e => e.ItemCode).HasMaxLength(30);
            entity.Property(e => e.MaterialModel).HasMaxLength(250);
            entity.Property(e => e.MaterialName).HasMaxLength(100);
            entity.Property(e => e.PartNo).HasMaxLength(30);
            entity.Property(e => e.PonumOfDay).HasColumnName("PONumOfDay");
            entity.Property(e => e.QuantityOfPo).HasColumnName("QuantityOfPO");
            entity.Property(e => e.Reason).HasMaxLength(250);
            entity.Property(e => e.SapmaterialGroup)
                .HasMaxLength(18)
                .HasColumnName("SAPMaterialGroup");
            entity.Property(e => e.SearchTerm).HasMaxLength(80);
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Class).WithMany(p => p.Materials)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Material__ClassI__3FD07829");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialTypeId)
                .HasConstraintName("FK__Material__Materi__3DE82FB7");

            entity.HasOne(d => d.OrderType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.OrderTypeId)
                .HasConstraintName("FK__Material__OrderT__3EDC53F0");

            entity.HasOne(d => d.Unit).WithMany(p => p.Materials)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK__Material__UnitId__3CF40B7E");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Materials)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__Material__Wareho__42ACE4D4");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3214EC07BD74D7B2");

            entity.ToTable("MaterialType");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TypeName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderTyp__3214EC078CEFA9E0");

            entity.ToTable("OrderType");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderTypeName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Param>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Param__3214EC07BE268778");

            entity.ToTable("Param");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Doing).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(2000);
            entity.Property(e => e.ParamName).HasMaxLength(200);
            entity.Property(e => e.Path).HasMaxLength(300);
            entity.Property(e => e.PersonRequire).HasMaxLength(100);
            entity.Property(e => e.TechStandar).HasMaxLength(100);
            entity.Property(e => e.Time)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ToolRequire).HasMaxLength(100);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.JobType).WithMany(p => p.Params)
                .HasForeignKey(d => d.JobTypeId)
                .HasConstraintName("FK__Param__JobTypeId__28ED12D1");

            entity.HasOne(d => d.Unit).WithMany(p => p.Params)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK__Param__Unit");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Priority__3214EC07DD3A2E02");

            entity.ToTable("Priority");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PriorityName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Problem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Problem__3214EC0799E6FDA7");

            entity.ToTable("Problem");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.ProblemName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producer__3214EC074474A13D");

            entity.ToTable("Producer");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProducerName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC07D03A6017");

            entity.ToTable("Role");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.RoleName).HasMaxLength(100);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Slgireason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SLGIReas__3214EC07D3DD1DCE");

            entity.ToTable("SLGIReason");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReasonName).HasMaxLength(150);
            entity.Property(e => e.Slaccount)
                .HasMaxLength(50)
                .HasColumnName("SLAccount");
            entity.Property(e => e.SldescriptionAcc)
                .HasMaxLength(250)
                .HasColumnName("SLDescriptionAcc");
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Slgrreason>(entity =>
        {
            entity.HasKey(e => e.ReasonCode).HasName("PK__SLGRReas__A6278DA276823A4C");

            entity.ToTable("SLGRReason");

            entity.Property(e => e.ReasonCode).HasMaxLength(50);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReasonName).HasMaxLength(150);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC0752AEFFE9");

            entity.ToTable("Supplier");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.ContactPerson).HasMaxLength(250);
            entity.Property(e => e.CountryId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName).HasMaxLength(250);
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Supplier__Countr__76619304");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unit__3214EC072E445668");

            entity.ToTable("Unit");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UnitName).HasMaxLength(250);
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3214EC0761531314");

            entity.ToTable("Warehouse");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPr).HasColumnName("IsPR");
            entity.Property(e => e.ProBuId).HasColumnName("PRO_bu_id");
            entity.Property(e => e.ProBuName)
                .HasMaxLength(150)
                .HasColumnName("PRO_bu_name");
            entity.Property(e => e.ProItemStock).HasColumnName("PRO_item_stock");
            entity.Property(e => e.SapPlant).HasMaxLength(12);
            entity.Property(e => e.Sldatabase)
                .HasMaxLength(50)
                .HasColumnName("SLDatabase");
            entity.Property(e => e.SldescriptionSite)
                .HasMaxLength(150)
                .HasColumnName("SLDescriptionSite");
            entity.Property(e => e.Slsite)
                .HasMaxLength(50)
                .HasColumnName("SLSite");
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.WarehouseName).HasMaxLength(100);

            entity.HasOne(d => d.Location).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Location");
        });

        modelBuilder.Entity<WorkerLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkerLe__3214EC070C76B00B");

            entity.ToTable("WorkerLevel");

            entity.Property(e => e.CreateBy).HasMaxLength(30);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateBy).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.WorkerLevelName).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
