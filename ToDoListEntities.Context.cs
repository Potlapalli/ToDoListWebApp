﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoListGrid
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class ToDoListDBEntities : DbContext
    {
        public ToDoListDBEntities()
            : base("name=ToDoListDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Item> Items { get; set; }
    
        public virtual int CreateItem(string name, string priority, string status)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var priorityParameter = priority != null ?
                new ObjectParameter("Priority", priority) :
                new ObjectParameter("Priority", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateItem", nameParameter, priorityParameter, statusParameter);
        }
    
        public virtual int DeleteItem(Nullable<long> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteItem", idParameter);
        }
    
        public virtual ObjectResult<ReadItems_Result> ReadItems()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadItems_Result>("ReadItems");
        }
    
        public virtual int UpdateItem(Nullable<long> id, string name, string priority, string status)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var priorityParameter = priority != null ?
                new ObjectParameter("Priority", priority) :
                new ObjectParameter("Priority", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateItem", idParameter, nameParameter, priorityParameter, statusParameter);
        }
    }
}
