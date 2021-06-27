using BackEnd_ProjetosLG.Context;
using BackEnd_ProjetosLG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_ProjetosLG.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantesController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        /// <summary>
        /// Obtem todos os  Participante
        /// </summary>
        /// <returns>Objetos Participante</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Participante>> Get()
        {
            try
            {
                return _context.Participantes.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erro ao tentar obter os Participantes do banco de dados");
            }

        }

       

        /// <summary>
        /// Obtem um participante pelo seu Id
        /// </summary>
        ///  Obtem um participante pelo seu Id
        /// <returns>Objetos participante</returns>
        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Participante> Get(int id)
        {
            try
            {

                var participante = _context.Participantes.FirstOrDefault(p => p.ParticipanteId == id);

                if (participante == null)
                {
                    return NotFound($"O Participante com id={id} não foi encontrada");
                }
                return participante;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erro ao tentar obter as Categorias do banco de dados");

            }
        }


        /// <summary>
        /// Inclui uma nova Participante
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST api/Participante
        ///     {
        ///        "participanteId": 1,
        ///        "nome": "Nome da Participante com 100 caracteres no maximo"
        ///       
        ///     }
        /// </remarks>
        /// <param name="participante">objeto Participante</param>
        /// <returns>Objeto Participante incluido</returns>
        [HttpPost]
        public ActionResult Post([FromBody] Participante  participante)
        {

            try
            {
                _context.Participantes.Add(participante);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = participante.ParticipanteId }, participante);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erro ao tentar criar um novo Participante");
            }

        }


        /// <summary>
        /// Atualiza um Participante
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     PUT api/Participante
        ///     {
        ///        "participanteId": 1,
        ///        "nome": "Nome da categoria com 100 caracteres no maximo"
        ///       
        ///     }
        /// </remarks>
        /// <param name="participante">objeto Participante</param>
        /// <returns>O objeto Ator Atualizado</returns>

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Participante participante)
        {
            try
            {
                if (id != participante.ParticipanteId)
                {
                    return BadRequest($"Não foi possível atualizar os dados com id={id}");
                }

                _context.Entry(participante).State = EntityState.Modified;
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
        /// Exclui um novo Participante
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     DELETE api/Participante
        ///     {
        ///        "participanteId": 1
        ///       
        ///       
        ///     }
        /// </remarks>
        /// <param name="id">objeto Participante</param>
        /// <returns>Objeto Participante excluido</returns>
        [HttpDelete("{id}")]
        public ActionResult<Participante> Delete(int id)
        {

            try
            {
                var categoria = _context.Participantes.FirstOrDefault(p => p.ParticipanteId == id);

                if (categoria == null)
                {
                    return NotFound($"Os dados com id={id} não foi encontrado");
                }

                _context.Participantes.Remove(categoria);
                _context.SaveChanges();
                return categoria;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            $"Erro ao excluir os dados de id = {id}");
            }

        }
    }
}
