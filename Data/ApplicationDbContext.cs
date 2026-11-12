using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace belajarASPDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<belajarASPDB.Models.NamaSiswaModel> NamaSiswaModel { get; set; } = default!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
