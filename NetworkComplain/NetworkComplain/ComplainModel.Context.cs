﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetworkComplain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NetworkComplaindbEntities : DbContext
    {
        public NetworkComplaindbEntities()
            : base("name=NetworkComplaindbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Complain> Complains { get; set; }
        public DbSet<ComplainStatu> ComplainStatus { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerStatu> ComputerStatus { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Usertype> Usertypes { get; set; }
    }
}
