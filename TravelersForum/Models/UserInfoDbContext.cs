
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Models {
    public class UserInfoDbContext : IdentityDbContext<IdentityUser> {
        public UserInfoDbContext(DbContextOptions<UserInfoDbContext> options): base(options) {

         }
    }
}