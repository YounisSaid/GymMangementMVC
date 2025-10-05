using GymMangementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangementDAL.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName)
                .HasMaxLength(20)
                .HasColumnType("varchar");
            
        }
    }
}
