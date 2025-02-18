using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.User
{
    public class UserETC : IEntityTypeConfiguration<Domain.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User.User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.FirstName).HasMaxLength(256);
            builder.Property(u => u.LastName).HasMaxLength(256);
        }
    }
}
