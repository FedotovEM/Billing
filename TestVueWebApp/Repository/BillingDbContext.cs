using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestVueWebApp.Repository.Models;

#nullable disable

namespace TestVueWebApp.Repository
{
    public partial class BillingDbContext : DbContext
    {
        public BillingDbContext()
        {
        }

        public BillingDbContext(DbContextOptions<BillingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonent> Abonents { get; set; }
        public virtual DbSet<AbonentMode> AbonentModes { get; set; }
        public virtual DbSet<Disrepair> Disrepairs { get; set; }
        public virtual DbSet<Executor> Executors { get; set; }
        public virtual DbSet<Mode> Modes { get; set; }
        public virtual DbSet<NachislSumma> NachislSummas { get; set; }
        public virtual DbSet<PaySumma> PaySummas { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ReceptionPoint> ReceptionPoints { get; set; }
        public virtual DbSet<Remain> Remains { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-F4DDTQQ\\SQLEXPRESS;Database=KURSOVOI_Billing_Correct;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Abonent>(entity =>
            {
                entity.Property(e => e.AccountCd).IsUnicode(false);

                entity.Property(e => e.District).IsUnicode(false);

                entity.Property(e => e.Fio).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.HasOne(d => d.StreetCdNavigation)
                    .WithMany(p => p.Abonents)
                    .HasForeignKey(d => d.StreetCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Abonent_Street");
            });

            modelBuilder.Entity<AbonentMode>(entity =>
            {
                entity.Property(e => e.AccountCd).IsUnicode(false);

                entity.HasOne(d => d.AccountCdNavigation)
                    .WithMany(p => p.AbonentModes)
                    .HasForeignKey(d => d.AccountCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AbonentMode_Abonent");

                entity.HasOne(d => d.ModeCdNavigation)
                    .WithMany(p => p.AbonentModes)
                    .HasForeignKey(d => d.ModeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AbonentMode_Mode");
            });

            modelBuilder.Entity<Disrepair>(entity =>
            {
                entity.Property(e => e.FailureName).IsUnicode(false);
            });

            modelBuilder.Entity<Executor>(entity =>
            {
                entity.Property(e => e.Fio).IsUnicode(false);
            });

            modelBuilder.Entity<Mode>(entity =>
            {
                entity.Property(e => e.ModeName).IsUnicode(false);

                entity.HasOne(d => d.ServiceCdNavigation)
                    .WithMany(p => p.Modes)
                    .HasForeignKey(d => d.ServiceCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mode_Services");
            });

            modelBuilder.Entity<NachislSumma>(entity =>
            {
                entity.Property(e => e.NachType).IsUnicode(false);

                entity.HasOne(d => d.AbonentModeСdNavigation)
                    .WithMany(p => p.NachislSummas)
                    .HasForeignKey(d => d.AbonentModeСd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NachislSumma_AbonMode");
            });

            modelBuilder.Entity<PaySumma>(entity =>
            {
                entity.Property(e => e.PayType).IsUnicode(false);

                entity.HasOne(d => d.AbonentModeСdNavigation)
                    .WithMany(p => p.PaySummas)
                    .HasForeignKey(d => d.AbonentModeСd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySumma_AbonMode");

                entity.HasOne(d => d.ReceptionPointCdNavigation)
                    .WithMany(p => p.PaySummas)
                    .HasForeignKey(d => d.ReceptionPointCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySumma_ReceptionPoint");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasOne(d => d.ModeCdNavigation)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ModeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Price_Servicess");
            });

            modelBuilder.Entity<ReceptionPoint>(entity =>
            {
                entity.Property(e => e.ReceptionName).IsUnicode(false);
            });

            modelBuilder.Entity<Remain>(entity =>
            {
                entity.Property(e => e.AccountCd).IsUnicode(false);

                entity.Property(e => e.Remainsum).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AccountCdNavigation)
                    .WithMany(p => p.Remains)
                    .HasForeignKey(d => d.AccountCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Remains_Abonent");

                entity.HasOne(d => d.ServiceCdNavigation)
                    .WithMany(p => p.Remains)
                    .HasForeignKey(d => d.ServiceCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Remains_Servicess");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.AccountCd).IsUnicode(false);

                entity.HasOne(d => d.AccountCdNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.AccountCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Abonent");

                entity.HasOne(d => d.ExecutorCdNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ExecutorCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Executor");

                entity.HasOne(d => d.FailureCdNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.FailureCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Disrepair");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceName).IsUnicode(false);

                entity.HasOne(d => d.UnitsCdNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.UnitsCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Unit");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.StreetName).IsUnicode(false);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitsName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
