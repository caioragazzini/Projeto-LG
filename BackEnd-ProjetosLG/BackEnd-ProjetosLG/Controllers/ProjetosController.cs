using BackEnd_ProjetosLG.Context;
using BackEnd_ProjetosLG.Models;
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

    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IConfiguration _config;

        public ProjetosController(AppDbContext context, IConfiguration configuration)
        {
            _config = configuration;
            _context = context;
        }

        /// <summary>
        /// Obtem todos os Projetos
        /// </summary>
        /// <returns>Objetos Projeto</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Projeto>> Get()
        {
            try
            {
                return _context.Projetos.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erro ao tentar obter os Projeto do banco de dados");

            }

        }

        [HttpGet("ProjetoParticipante")]
        //public ActionResult<IEnumerable<Projeto>> GetProjetosParticipantes()
        //{
        //    //try
        //    //{
        //    //    return _context.Projetos.Include(x => x.Participantes).ToList();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return StatusCode(StatusCodes.Status500InternalServerError,
        //    //         "Erro ao tentar obter os Projeto e PArticipantes do banco de dados");

        //    //}

        //}

        /// <summary>
        /// Obtem um Projeto pelo seu Id
        /// </summary>
        ///  Obtem um Projeto pelo seu Id
        /// <returns>Objetos Projeto</returns>
        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Projeto> Get(int id)
        {
            try
            {
                var filme = _context.Projetos.FirstOrDefault(p => p.ProjetoId == id);
                if (filme == null)
                {
                    return NotFound($"O Projeto com id={id} não foi encontrado");
                }
                return filme;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erro ao tentar obter os Projetos do banco de dados");

            }
        }

        //POST/ PUT/ DELETE
        /// <summary>
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST api/Projeto
        ///     {
        ///        "ProjetoId": 1,
        ///        "nome": "titulo do filme com 100 caracteres no maximo",
        ///        "DataInicio": 04/03/1978,
        ///        "DataFim": "04/03/2021",
        ///        "ValorProjeto": 200.00,
        ///        "Risco": de 0 a 3,
        ///        "ParticipanteId": id vinculado a tabela de Participante,
        ///                  
        ///     }
        /// </remarks>
        /// <param name="Projeto">objeto Projeto</param>
        /// <returns>Objeto Projeto incluido</returns>
        [HttpPost]
        public ActionResult Post([FromBody] Projeto projeto)
        {
            try
            {
                _context.Projetos.Add(projeto);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterFilme",
                    new { id = projeto.ProjetoId }, projeto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erro ao tentar criar um novo Projeto");
            }


        }

        /// <summary>
        /// Atualiza um Projeto pelo seu ID
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     PUT api/Filme/id
        ///     {            
        ///        "ProjetoId": 1,
        ///        "nome": "titulo do filme com 100 caracteres no maximo",
        ///        "DataInicio": 04/03/1978,
        ///        "DataFim": "04/03/2021",
        ///        "ValorProjeto": 200.00,
        ///        "Risco": de 0 a 3,
        ///        "ParticipanteId": id vinculado a tabela de Participante,
        ///       
        ///     }
        /// </remarks>
        /// <param name="Projeto">objeto Projeto</param>
        /// <returns>Objeto Projeto atualizado</returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Projeto  projeto)
        {
            try
            {
                if (id != projeto.ProjetoId)
                {
                    return BadRequest($"Não foi possível atualizar os dados com id={id}");
                }

                _context.Entry(projeto).State = EntityState.Modified;
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
        /// Exclui um Projeto
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST api/Projeto
        ///     {
        ///        "ProjetoId": 1
        ///       
        ///       
        ///     }
        /// </remarks>
        /// <param name="id">objeto Projeto</param>
        /// <returns>Objeto Projeto exluido</returns>
        [HttpDelete("{id}")]
        public ActionResult<Projeto> Delete(int id)
        {
            try
            {
                var filme = _context.Projetos.FirstOrDefault(p => p.ProjetoId == id);

                if (filme == null)
                {
                    return NotFound($"Os dados com id={id} não foi encontrado");
                }

                _context.Projetos.Remove(filme);
                _context.SaveChanges();
                return filme;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                              $"Erro ao excluir os dados de id = {id}");
            }

        }


    }
}
