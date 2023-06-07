using CodeFirst.Models.Configs;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<Medicament> medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }



        public MainDbContext(DbContextOptions options) : base(options)
        {


        }

        protected MainDbContext()
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Encrypt=false;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicamentEfConfiguration).Assembly);

            //modelBuilder.Entity<Student>(s =>

            //{
            //    s.hasData(
            //    new Student { IdStudent = 1, FirstName = "Jan", LastName = "Kowalski", Address = "Warsaw" },
            //    new Student { IdStudent = 2, FirstName = "Andrzej", LastName = "Malewski", Address = "Warsaw" }

            //    );

            //};



        }
    }
}
