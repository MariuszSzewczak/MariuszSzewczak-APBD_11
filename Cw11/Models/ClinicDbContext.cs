using System;
using System.Collections.Generic;
using Cw11.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cw11.Models
{
    public class ClinicDbContext: DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PrescriptionMedicament> Prescription_Medicament { get; set; }

        public ClinicDbContext(){}
        public ClinicDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEFConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEFConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentEFConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEFConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEFConfiguration());
            SeedData(modelBuilder);
        }
        
        protected void SeedData(ModelBuilder modelBuilder)
        {
            var doctors = new List<Doctor>();
            doctors.Add(new Doctor()
            {
                IdDoctor = 1,
                FirstName = "Mario",
                LastName = "Bros",
                Email = "mario.bros@domein.com"
            });
            doctors.Add(new Doctor()
            {
                IdDoctor = 2,
                FirstName = "Luigi",
                LastName = "Bros",
                Email = "luigi.bros@domein.com"
            });
            modelBuilder.Entity<Doctor>().HasData(doctors);
            
            var patients= new List<Patient>();
            patients.Add(new Patient()
            {
                IdPatient = 1,
                FirstName = "Pacjent1",
                LastName = "Nazwisko1",
                Birthdate = Convert.ToDateTime("01.01.1989")
            });
            patients.Add(new Patient()
            {
                IdPatient = 2,
                FirstName = "Pacjent2",
                LastName = "Pacjent2",
                Birthdate = Convert.ToDateTime("01.01.1990")
            });
            modelBuilder.Entity<Patient>().HasData(patients);
            
            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament()
            {
                IdMedicament = 1,
                Name = "Piguła1",
                Description = "Piguła1",
                Type = "Piguła"
            });
            medicaments.Add(new Medicament()
            {
                IdMedicament = 2,
                Name = "Piguła2",
                Description = "Piguła2",
                Type = "Piguła"
            });
            modelBuilder.Entity<Medicament>().HasData(medicaments);
            
            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription()
            {
                IdPrescription = 1,
                Date = Convert.ToDateTime("01.01.2020"),
                DueDate = Convert.ToDateTime("01.02.2020"),
                IdPatient = 1,
                IdDoctor = 1
            });
            prescriptions.Add(new Prescription()
            {
                IdPrescription = 2,
                Date = Convert.ToDateTime("01.03.2020"),
                DueDate = Convert.ToDateTime("01.04.2020"),
                IdPatient = 2,
                IdDoctor = 2
            });
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            
            var prescriptions_medicaments = new List<PrescriptionMedicament>();
            prescriptions_medicaments.Add(new PrescriptionMedicament()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 1,
                Details = "Once"
            });
            modelBuilder.Entity<PrescriptionMedicament>().HasData(prescriptions_medicaments);
            


        }

        
    }
}