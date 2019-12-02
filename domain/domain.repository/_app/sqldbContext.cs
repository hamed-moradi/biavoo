using domain.repository.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repository._app {
    public partial class SqlDBContext: DbContext {
        public SqlDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        //public int GetNextSequenceValue() {
        //    var rawQuery = Database.SqlQuery<int>("SELECT NEXT VALUE FOR [dbo].[];");
        //    var task = rawQuery.SingleAsync();
        //    var nextVal = task.Result;
        //    return nextVal;
        //}
        public virtual DbSet<Admin_Entity> Admins { get; set; }
        public virtual DbSet<Role_Entity> Roles { get; set; }
        public virtual DbSet<Customer_Entity> Customers { get; set; }
        public virtual DbSet<User_Entity> Users { get; set; }
        public virtual DbSet<ModuleReference_Entity> ModuleReferences { get; set; }
        public virtual DbSet<Role2Module_Entity> Role2Modules { get; set; }
        public virtual DbSet<Page_Entity> Pages { get; set; }
        public virtual DbSet<Product_Entity> Products { get; set; }
        public virtual DbSet<Business_Entity> Businesses { get; set; }
        public virtual DbSet<Category_Entity> Categories { get; set; }
        public virtual DbSet<ReceivedSms_Entity> ReceivedSmses { get; set; }
        public virtual DbSet<Session_Entity> Sessions { get; set; }
        public virtual DbSet<SentSms_Entity> SentSms { get; set; }
    }
}