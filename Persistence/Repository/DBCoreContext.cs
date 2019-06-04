using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DBCoreContext : DbContext
    {
        public DBCoreContext(DbContextOptions<DBCoreContext> options)
           : base(options)
        { }

        public DbSet<Transacao> Transacoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFDatabase;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
    }
}
