using RCD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("Dbconnection")
        {
        }

        public DbSet<File> File { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FileType> FileType { get; set; }
        public DbSet<Metadata> Metadata { get; set; }
        public DbSet<MetadataType> MetadataType { get; set; }
        public DbSet<Setting> Setting { get; set; }

    }
}
