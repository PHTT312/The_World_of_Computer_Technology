﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldPC.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WorldPCEntities : DbContext
    {
        public WorldPCEntities()
            : base("name=WorldPCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<computer_equipment> computer_equipment { get; set; }
        public virtual DbSet<crash_history> crash_history { get; set; }
        public virtual DbSet<gender> gender { get; set; }
        public virtual DbSet<history_list> history_list { get; set; }
        public virtual DbSet<info> info { get; set; }
        public virtual DbSet<model> model { get; set; }
        public virtual DbSet<post> post { get; set; }
        public virtual DbSet<repair_order> repair_order { get; set; }
        public virtual DbSet<staff> staff { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<type> type { get; set; }
    }
}