using BackEnd_ProjetosLG.Context;
using BackEnd_ProjetosLG.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_ProjetosLG.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ParticipanteProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IConfiguration _config;

        public ParticipanteProjetosController(AppDbContext context, IConfiguration configuration)
        {
            _config = configuration;
            _context = context;
        }


        /// <summary>
        /// Obtem todos os participanteProjeto
        /// </summary>
        /// <returns>Objetos participanteProjeto</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ParticipanteProjeto>> Get()
        {
            try
            {
                return _context.ParticipanteProjetos.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erro ao tentar obter os participante Projeto do banco de dados");

            }

        }


        [HttpGet("{id}")]
        public ActionResult<ParticipanteProjeto> Get(int id)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conexao.Open();

                    var teste = conexao.Query<dynamic>("SELECT distinct p.ParticipanteId, p.Nome from participantes as p inner join participanteprojeto as a on p.ParticipanteId = a.ParticipanteId inner join projetos as b on a.ProjetoId = b.ProjetoId   Where b.ProjetoId = " + id );

                    return Ok(teste);

                }

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erro ao tentar obter os Atores e Filmes do banco de dados");

            }


        }

        /// <summary>
        /// Obtem um participanteProjeto pelo seu Id
        /// </summary>
        ///  Obtem um participanteProjeto pelo seu Id
        /// <returns>Objetos participanteProjeto</returns>
        //[HttpGet("{id}")]
        //public ActionResult<ParticipanteProjeto> Get(int id)
        //{
        //    try
        //    {
        //        var participanteProjeto = _context.ParticipanteProjetos.FirstOrDefault(p => p.ParticipantePojetoId == id);

        //        if (participanteProjeto == null)
        //        {
        //            return NotFound($"Os participanteProjeto com id={id} não foram encontrados");
        //        }
        //        return participanteProjeto;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //             "Erro ao tentar obter os  participanteProjeto do banco de dados");

        //    }
        //}

        /// <summary>
        /// Inclui uma novo participanteProjeto
        /// </summary>
        /// <remarks>
        /// <param name="participanteProjeto">objeto participanteProjeto</param>
        /// <returns>O objeto participanteProjeto incluido</returns>
        /// <remarks>O objeto participanteProjeto incluido</remarks>
        [HttpPost]
        public ActionResult Post([FromBody] ParticipanteProjeto participanteProjeto)
        {
            try
            {

                _context.ParticipanteProjetos.Add(participanteProjeto);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterParticipanteProjeto",
                    new { id = participanteProjeto.ParticipantePojetoId }, participanteProjeto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erro ao tentar criar uma novo Ator Filme");
            }


        }

        /// <summary>
        /// Atualiza um novo participanteProjeto
        /// </summary>
        /// <remarks>
        /// <param name="ParticipanteProjeto">objetoparticipanteProjeto</param>
        /// <returns>O objeto participanteProjeto incluido</returns>
        /// <remarks>O objeto participanteProjeto incluido</remarks>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ParticipanteProjeto participanteProjeto)
        {
            try
            {
                if (id != participanteProjeto.ParticipantePojetoId)
                {
                    return BadRequest($"Não foi possível atualizar os dados com id={id}");
                }

                _context.Entry(participanteProjeto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"Dados com id={id} foi atualizada com sucesso");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Erro ao tentar atualizar dados com id={id}");
            }


        }

        /// <summary>
        /// Exclui um participanteProjeto
        /// </summary>
        /// <remarks>
        /// <param name="participanteProjeto">objeto participanteProjeto</param>
        /// <returns>O objeto participanteProjeto incluido</returns>
        /// <remarks>O objeto participanteProjeto incluido</remarks>
        [HttpDelete("{id}")]
        public ActionResult<ParticipanteProjeto> Delete(int id)
        {
            try
            {
                var participanteProjeto = _context.ParticipanteProjetos.FirstOrDefault(p => p.ParticipantePojetoId == id);

                if (participanteProjeto == null)
                {
                    return NotFound($"Os dados com id={id} não foi encontrado");
                }

                _context.ParticipanteProjetos.Remove(participanteProjeto);
                _context.SaveChanges();
                return participanteProjeto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                              $"Erro ao excluir os dados de id = {id}");
            }

        }

    }
}


