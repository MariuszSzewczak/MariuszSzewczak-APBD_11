using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.Configurations
{
    public class DoctorEFConfiguration: IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor); 
            builder.Property(d => d.FirstName).IsRequired(); 
            builder.Property(d => d.LastName).IsRequired();
            builder.Property(d => d.Email).IsRequired();

        }
    }
}