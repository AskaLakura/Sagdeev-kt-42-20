﻿using Sagdeev_kt4220.Database.Configurations;
using Sagdeev_kt4220.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Sagdeev_kt4220.Database
{
    public class PrepodDbcontext : DbContext
    {
        //Добавляем таблицы
        DbSet<Kafedra> Kafedra { get; set; }
        DbSet<Stepen> Stepen { get; set; }
        DbSet<Prepod> Prepod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
            modelBuilder.ApplyConfiguration(new StepenConfiguration());
        }
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}