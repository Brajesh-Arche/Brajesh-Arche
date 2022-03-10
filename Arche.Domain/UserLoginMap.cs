using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arche.Domain
{
    public class UserLoginMap
    {
        public UserLoginMap(EntityTypeBuilder<UserLogin> user)
        {
            //user.HasKey(x => x.UserId);
            user.Property(x => x.UserName).IsRequired();
            user.Property(x => x.UserPassword).IsRequired();
        }
    }
}
