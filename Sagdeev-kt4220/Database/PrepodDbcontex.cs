using Sagdeev_kt4220.Database.Configurations;
using Sagdeev_kt4220.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Sagdeev_kt4220.Database
{
    public class PrepodDbcontext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Kafedra> Kafedra { get; set; }
        public DbSet<Prepod> Prepod { get; set; }
        public DbSet<Stepen> Stepen { get; set; }
        public DbSet<Doljnost> Doljnost { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
            modelBuilder.ApplyConfiguration(new StepenConfiguration());
            modelBuilder.ApplyConfiguration(new DoljnostConfiguration());
        }
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}