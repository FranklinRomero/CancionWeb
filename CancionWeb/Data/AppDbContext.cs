using CancionWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancionWeb.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
           
        }
    }
}
