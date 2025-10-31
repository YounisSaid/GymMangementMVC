using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GymMangementDAL.Entities;
namespace GymMangementDAL.Data.Configurations
{
    public class TrainerConfiguration : GymUserConfiguration<Trainer>,IEntityTypeConfiguration<Trainer>
    {
        public new void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(t => t.CreatedAt)
               .HasColumnName("HireDate")
               .HasDefaultValueSql("GETDATE()");

            base.Configure(builder);
        }
    }
   
}
