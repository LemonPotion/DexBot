using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(person => person.Id).HasName("personId");
        builder.OwnsOne(person => person.FullName, fullName =>
        {
            fullName.Property(person => person.FirstName).IsRequired().HasColumnName("firstName");
            fullName.Property(person => person.LastName).IsRequired().HasColumnName("lastName");
            fullName.Property(person => person.MiddleName).HasColumnName("middleName");
        });
        builder.Property(person => person.BirthDay).IsRequired().HasColumnName("birthDay");
        builder.Property(person => person.PhoneNumber).IsRequired().HasColumnName("phoneNumber");
        builder.Property(person => person.Telegram).IsRequired().HasColumnName("telegram");
        builder.Property(person => person.Gender).IsRequired().HasColumnName("gender");
        builder.Property(person => person.CreationDate).IsRequired().HasColumnName("creationDate");
        
        builder.HasMany(person => person.CustomFields)
            .WithOne()
            .HasForeignKey(cf => cf.PersonId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}