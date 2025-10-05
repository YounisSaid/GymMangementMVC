using GymMangementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangementDAL.Data.Configurations
{
    public class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.Ignore(hr=>hr.CreatedAt);
            builder.Ignore(hr => hr.UpdatedAt);

        }
    }
   
}
