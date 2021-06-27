using BackEnd_ProjetosLG.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_ProjetosLG.Controllers
{
    public class ParticipanteProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IConfiguration _config;

        public ParticipanteProjetosController(AppDbContext context, IConfiguration configuration)
        {
            _config = configuration;
            _context = context;
        }
    }
}
