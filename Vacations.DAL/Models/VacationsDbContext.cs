using System;
using Microsoft.AspNetCore.Identity;
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

        public virtual DbSet<IdentityRoleClaim<string>> AspNetRoleClaims { get; set; }
        public virtual DbSet<Role> AspNetRoles { get; set; }
        public virtual DbSet<IdentityUserClaim<string>> AspNetUserClaims { get; set; }
        public virtual DbSet<IdentityUserLogin<string>> AspNetUserLogins { get; set; }
        public virtual DbSet<IdentityUserRole<string>> AspNetUserRoles { get; set; }
        public virtual DbSet<User> AspNetUsers { get; set; }
        public virtual DbSet<IdentityUserToken<string>> AspNetUserTokens { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeStatus> EmployeeStatus { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }
        public virtual DbSet<Vacation> Vacation { get; set; }
        public virtual DbSet<VacationStatus> VacationStatus { get; set; }
        public virtual DbSet<VacationTypes> VacationTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__AspNetUs__A9D10534512328AD")
                    .IsUnique();

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_AspNetUsers_EmployeeID_Unique")
                    .IsUnique();

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.EmployeeStatusId);

                entity.HasIndex(e => e.JobTitleId);

                entity.HasIndex(e => e.TeamId);

                entity.HasIndex(e => e.WorkEmail)
                    .HasName("UQ__Employee__D56321090CD0BA4C")
                    .IsUnique();

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

                entity.Property(e => e.ImgUrl).HasMaxLength(200);

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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.Property(e => e.JobTitleId)
                    .HasColumnName("JobTitleID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.TeamLeadId);

                entity.Property(e => e.TeamId)
                    .HasColumnName("TeamID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

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

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

                entity.Property(e => e.VacationId).HasColumnName("VacationID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.TransactionAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("Transaction_AuthorID_FK");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TransactionEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transaction_EmployeeID_FK");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transaction_TransactionTypeID_FK");

                entity.HasOne(d => d.Vacation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.VacationId)
                    .HasConstraintName("Transaction_VacationID_FK");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("TransactionTypeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.Property(e => e.VacationTypesId).HasColumnName("VacationTypesID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Vacation)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vacation_EmployeeID_FK");

                entity.HasOne(d => d.VacationStatus)
                    .WithMany(p => p.Vacation)
                    .HasForeignKey(d => d.VacationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vacation_VacationStatusID_FK");

                entity.HasOne(d => d.VacationTypes)
                    .WithMany(p => p.Vacation)
                    .HasForeignKey(d => d.VacationTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vacations_VacationTypesID_FK");
            });

            modelBuilder.Entity<VacationStatus>(entity =>
            {
                entity.Property(e => e.VacationStatusId)
                    .HasColumnName("VacationStatusID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VacationTypes>(entity =>
            {
                entity.Property(e => e.VacationTypesId)
                    .HasColumnName("VacationTypesID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
