using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.Configurations
{
    public class PatientEFConfiguration: IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient);
            builder.Property(d => d.FirstName).IsRequired();
            builder.Property(d => d.LastName).IsRequired();
            builder.Property(d => d.Birthdate).IsRequired();

        }
    }
}