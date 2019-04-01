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
        //    var rawQuery = Database.SqlQuery<int>("SELECT NEXT VALUE FOR [dbo].[Sequence-LeaderBoardGroup];");
        //    var task = rawQuery.SingleAsync();
        //    var nextVal = task.Result;
        //    return nextVal;
        //}

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Notification> Notifications { get; set; }
        //public virtual DbSet<Page> Pages { get; set; }
        //public virtual DbSet<ReceivedSms> ReceivedSmses { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<Session> Sessions { get; set; }
        //public virtual DbSet<SentSms> SentSms { get; set; }
    }
}