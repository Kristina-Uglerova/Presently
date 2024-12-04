using Microsoft.EntityFrameworkCore;
using PresentlyServer.Models;
using System.Drawing;

namespace PresentlyServer
{
    public class PresentlyDbContext(DbContextOptions<PresentlyDbContext> options) : DbContext(options)
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbWish> Wishes { get; set; }
        public DbSet<DbWishUrl> WishUrls { get; set; }
    }
}