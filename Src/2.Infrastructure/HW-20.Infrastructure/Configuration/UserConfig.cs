using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HW_20.Domain.Entites.User;

namespace HW_20.Infrastructure.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Users");
            builder.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(c => c.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(c => c.PhoneNumber)
                  .IsRequired()
                  .HasMaxLength(50);
            builder.HasData(new User
            {
                Id = 1,
                Name = "Aso",
                LastName = "lotfi",
               PhoneNumber="09189827366"

            });
        }
    }
}
