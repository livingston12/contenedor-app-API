﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contenedor_WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class App_contenedorEntities : DbContext
    {
        public App_contenedorEntities()
            : base("name=App_contenedorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<groups_mod> groups_mod { get; set; }
        public virtual DbSet<modules_app> modules_app { get; set; }
        public virtual DbSet<rols_app> rols_app { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<users_mod> users_mod { get; set; }
    }
}