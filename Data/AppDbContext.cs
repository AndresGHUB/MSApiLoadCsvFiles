using Microsoft.EntityFrameworkCore;
using MSApiLoadCsvFiles.Models;

namespace MSApiLoadCsvFiles.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ParamFilesUpload> ParamFilesUploads {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParamFilesUpload>().ToTable("PARAM_FILES_UPLOAD");
        }
    }
}
