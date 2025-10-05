using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GymMangementDAL.Entities;
namespace GymMangementDAL.Data.Configurations
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(t => t.CreatedAt)
               .HasColumnName("HireDate")
               .HasDefaultValueSql("GETDATE()");


        }
    }
   
}
