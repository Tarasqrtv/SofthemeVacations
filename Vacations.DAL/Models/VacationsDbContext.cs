using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vacations.DAL.Models
{
    public partial class VacationsDbContext : DbContext
    {
        private readonly string connectionString;

        public VacationsDbContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        public VacationsDbContext(DbContextOptions<VacationsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeStatus> EmployeeStatus { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }
        public virtual DbSet<Vacation> Vacation { get; set; }
        public virtual DbSet<VacationStatus> VacationStatus { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
           {
               b.Property<string>("Id")
                   .ValueGeneratedOnAdd();

               b.Property<int>("AccessFailedCount");

               b.Property<string>("ConcurrencyStamp")
                   .IsConcurrencyToken();

               b.Property<string>("Email")
                   .HasMaxLength(256);

               b.Property<bool>("EmailConfirmed");

               b.Property<Guid>("EmployeeID");

               b.Property<bool>("LockoutEnabled");

               b.Property<DateTimeOffset?>("LockoutEnd");

               b.Property<string>("NormalizedEmail")
                   .HasMaxLength(256);

               b.Property<string>("NormalizedUserName")
                   .HasMaxLength(256);

               b.Property<string>("PasswordHash");

               b.Property<string>("PhoneNumber");

               b.Property<bool>("PhoneNumberConfirmed");

               b.Property<string>("SecurityStamp");

               b.Property<bool>("TwoFactorEnabled");

               b.Property<string>("UserName")
                   .HasMaxLength(256);

               b.HasKey("Id");

               //               b.HasIndex("IX_EmployeeID");

               b.HasIndex("NormalizedEmail")
                   .HasName("EmailIndex");

               b.HasIndex("NormalizedUserName")
                   .IsUnique()
                   .HasName("UserNameIndex")
                   .HasFilter("[NormalizedUserName] IS NOT NULL");

               b.HasOne(u => u.Employee)
                   .WithOne(e => e.User)
                   .HasForeignKey<User>("EmployeeID")
                   .HasConstraintName("AspNetUsers_EmployeeID_FK");

               b.ToTable("AspNetUsers");
           });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.EmployeeStatusId);

                entity.HasIndex(e => e.JobTitleId);

                entity.HasIndex(e => e.TeamId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.EmployeeStatusId).HasColumnName("EmployeeStatusID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalEmail).HasMaxLength(256);

                entity.Property(e => e.Skype).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.TelephoneNumber).HasMaxLength(20);

                entity.Property(e => e.WorkEmail)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.EmployeeStatus)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmployeeStatusId)
                    .HasConstraintName("Employee_EmployeeStatusID_FK");

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.JobTitleId)
                    .HasConstraintName("Employee_JobTitleID_FK");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("Employee_TeamID_FK");
            });

            modelBuilder.Entity<EmployeeStatus>(entity =>
            {
                entity.Property(e => e.EmployeeStatusId)
                    .HasColumnName("EmployeeStatusID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.Property(e => e.JobTitleId)
                    .HasColumnName("JobTitleID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.TeamLeadId);

                entity.Property(e => e.TeamId)
                    .HasColumnName("TeamID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.TeamLeadId).HasColumnName("TeamLeadID");

                entity.HasOne(d => d.TeamLead)
                    .WithMany(p => p.TeamNavigation)
                    .HasForeignKey(d => d.TeamLeadId)
                    .HasConstraintName("Team_TeamLeadID_FK");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.TransactionTypeId);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Transaction_EmployeeID_FK");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .HasConstraintName("Transaction_TransactionTypeID_FK");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("TransactionTypeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Vacation>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.VacationStatusId);

                entity.Property(e => e.VacationId)
                    .HasColumnName("VacationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndVocationDate).HasColumnType("date");

                entity.Property(e => e.StartVocationDate).HasColumnType("date");

                entity.Property(e => e.VacationStatusId).HasColumnName("VacationStatusID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Vacation)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Vacation_EmployeeID_FK");

                entity.HasOne(d => d.VacationStatus)
                    .WithMany(p => p.Vacation)
                    .HasForeignKey(d => d.VacationStatusId)
                    .HasConstraintName("Vacation_VacationStatusID_FK");
            });

            modelBuilder.Entity<VacationStatus>(entity =>
            {
                entity.Property(e => e.VacationStatusId)
                    .HasColumnName("VacationStatusID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
