namespace MadBug.Data
{
    using MagBug.Domain;
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bug = modelBuilder.Entity<Bug>();
            bug.HasKey(x => x.Id).Property(x=>x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            bug.Property(x => x.IsFixed).IsRequired();
            bug.Property(x => x.CreatedAt).IsRequired();
            bug.Property(x => x.Body).HasMaxLength(1000);
            bug.Property(x => x.Title).HasMaxLength(50);
            bug.Property(x => x.StepToReproduce).HasMaxLength(100);
            bug.Property(x => x.Severity).IsRequired();
            bug.HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);
            bug.Property(x => x.RowVersion).IsConcurrencyToken();

            var user = modelBuilder.Entity<User>();
            user.HasKey(x => x.Id);
            user.Property(x => x.CreatedAt).IsRequired();
            user.Property(x => x.DisplayName).HasMaxLength(100);

        }

        public virtual DbSet<Bug> Bugs { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }


}