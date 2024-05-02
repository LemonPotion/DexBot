using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class CustomFieldsConfiguration : IEntityTypeConfiguration<CustomFields<string>>
{
    public void Configure(EntityTypeBuilder<CustomFields<string>> builder)
    {
        builder.HasKey(cf => cf.Id).HasName("customFieldId");
        builder.Property(cf => cf.Name).IsRequired().HasColumnName("name");
        builder.Property(cf => cf.Value).IsRequired().HasColumnName("value");
        builder.Property(cf => cf.CreationDate).IsRequired().HasColumnName("creationDate");
    }
}