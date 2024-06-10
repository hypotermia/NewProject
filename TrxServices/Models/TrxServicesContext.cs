﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrxServices.Models
{
    public partial class TrxServicesContext : DbContext
    {
        public TrxServicesContext()
        {
        }

        public TrxServicesContext(DbContextOptions<TrxServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DailyReport> DailyReports { get; set; }
        public virtual DbSet<DetailTransaction> DetailTransactions { get; set; }
        public virtual DbSet<MonthlyReport> MonthlyReports { get; set; }
        public virtual DbSet<Reporting> Reportings { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<WeeklyReport> WeeklyReports { get; set; }
        public virtual DbSet<YearlyReport> YearlyReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DailyReport");

                entity.Property(e => e.ProductsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalDaily)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("totalDaily");
            });

            modelBuilder.Entity<DetailTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DetailTransaction");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPerTrx)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("totalPerTrx");
            });

            modelBuilder.Entity<MonthlyReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MonthlyReport");

                entity.Property(e => e.ProductsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalMonthly)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("totalMonthly");
            });

            modelBuilder.Entity<Reporting>(entity =>
            {
                entity.ToTable("Reporting");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPayment).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPerTrx)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("totalPerTrx");
            });

            modelBuilder.Entity<WeeklyReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WeeklyReport");

                entity.Property(e => e.ProductsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalWeekly)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("totalWeekly");
            });

            modelBuilder.Entity<YearlyReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("YearlyReport");

                entity.Property(e => e.ProductsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalYearly)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("totalYearly");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}