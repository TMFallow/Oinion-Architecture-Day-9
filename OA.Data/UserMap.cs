using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id);

            entityTypeBuilder.Property(t => t.Id).IsRequired().ValueGeneratedNever();

            entityTypeBuilder.Property(t => t.UserName).IsRequired();

            entityTypeBuilder.Property(t => t.Password).IsRequired();

            entityTypeBuilder.Property(t => t.Email);

            entityTypeBuilder.HasOne(t => t.UserInfo)
                .WithOne(u => u.User)
                .HasForeignKey<UserInfo>(t => t.Id);
        }

    }
}
