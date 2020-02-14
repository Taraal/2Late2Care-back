using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace _2Late2CareBack.Models
{
    class ContexteBDD : DbContext
    {
        public ContexteBDD()
        {
        }

        public ContexteBDD(DbContextOptions<ContexteBDD> options) : base(options){

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Classe> Classes {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketTag>().HasKey(sc => new { sc.TagId, sc.TicketId });
        }


    }
}
