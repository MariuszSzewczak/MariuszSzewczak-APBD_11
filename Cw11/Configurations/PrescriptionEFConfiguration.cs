using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.Configurations
{
    public class PrescriptionEFConfiguration: IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription);
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.DueDate).IsRequired();
            
            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(p => p.IdPatient)
                .IsRequired();

            builder.HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(p => p.IdDoctor)
                .IsRequired();
        }
    }
}