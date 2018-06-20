using System;
using PresseLogg.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PresseLogg.DAL
{
    public class LoggContext : DbContext
    {
        public LoggContext()
            : base("LoggContext")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<PressLog> PressLogs { get; set; }
        public DbSet<ShiftTask> ShiftTasks { get; set; }
        public DbSet<ShiftTaskGroup> ShiftTaskGroups { get; set; }
        public DbSet<ShiftLog> ShiftLogs { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}