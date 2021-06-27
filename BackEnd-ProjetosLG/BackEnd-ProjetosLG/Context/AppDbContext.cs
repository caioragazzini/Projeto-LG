using LG__Lorem_Ipsum_Inc_Projetos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LG__Lorem_Ipsum_Inc_Projetos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public AppDbContext()
        {

        }
       
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<ParticipanteProjeto> ParticipanteProjetos { get; set; }

    }
}
