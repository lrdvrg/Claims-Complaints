﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Propietaria.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReclaimsAndComplaints2Entities : DbContext
    {
        public ReclaimsAndComplaints2Entities()
            : base("name=ReclaimsAndComplaints2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<ComplaintType> ComplaintType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<IdentificationType> IdentificationType { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Reclaim> Reclaim { get; set; }
        public virtual DbSet<ReclaimsAndComplaintsStatus> ReclaimsAndComplaintsStatus { get; set; }
        public virtual DbSet<ReclaimType> ReclaimType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleOperation> RoleOperation { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        public virtual DbSet<Satisfaction> Satisfaction { get; set; }
    }
}
