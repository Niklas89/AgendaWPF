using AgendaWPF.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AgendaWPF.Data
{
    public partial class DbConnect : DbContext
    {
        public DbConnect()
        {
        }

        public DbConnect(DbContextOptions<DbConnect> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Broker> Brokers { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6IV8GIO\\SQLEXPRESS;Database=agendaWPF;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
