using MemberRegistration.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemberRegistration.DataAccessLayer.FluentValidation.Mappings
{
    public class UserLoginMap : IEntityTypeConfiguration<Login>
    {

        public void Configure(EntityTypeBuilder<Login> login)
        {
            login.ToTable("Users");
            login.HasKey(u => u.LoginId);
            login.Property(u => u.LoginId).HasColumnName("UserId");
            login.Property(u => u.Username).HasColumnName("UserName");
            login.Property(u => u.Password).HasColumnName("Password");

        }
    }
}
