using System;
using Microsoft.EntityFrameworkCore;

namespace SignalRExample.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
