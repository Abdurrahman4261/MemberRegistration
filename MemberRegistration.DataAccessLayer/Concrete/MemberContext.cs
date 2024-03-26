using MemberRegistration.EntityLayer.Concrete;
using MemberRegistration.EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.DataAccessLayer.Concrete
{
    public class MemberContext : DbContext

    {
        
        public MemberContext(DbContextOptions<MemberContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AllUserInfos> AllUserInfos { get; set; }
        
    }
}
