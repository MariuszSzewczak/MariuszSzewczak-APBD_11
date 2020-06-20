using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.Configurations
{
    public class PrescriptionMedicamentEFConfiguration: IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(e => new { e.IdPrescription, e.IdMedicament });
            
            builder.HasOne<Medicament>()
                .WithMany()
                .HasForeignKey(p => p.IdMedicament)
                .IsRequired();

            builder.HasOne<Prescription>()
                .WithMany()
                .HasForeignKey(p => p.IdPrescription)
                .IsRequired();

            builder.Property(e => e.Dose).IsRequired();
            builder.Property(e => e.Details).IsRequired();
           
        }
    }
}