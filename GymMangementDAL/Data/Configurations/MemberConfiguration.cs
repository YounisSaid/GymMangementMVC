using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMangementDAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


using Microsoft.EntityFrameworkCore;
namespace GymMangementDAL.Data.Configurations
{
    public class MemberConfiguration : GymUserConfiguration<Member>,IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.CreatedAt)
                .HasColumnName("JoinDate")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.HealthRecord)
                .WithOne()
                .HasForeignKey<HealthRecord>(hr => hr.Id);
            base.Configure(builder);
        }
    }
   
}
