//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPTC.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SPTCEntities : DbContext
    {
        private static SPTCEntities _context;
        public SPTCEntities()
            : base("name=SPTCEntities")
        {
        }

        public static SPTCEntities GetContext()
        {
            if (_context == null)
                _context = new SPTCEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Tarifs> Tarifs { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
