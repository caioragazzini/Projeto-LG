using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_ProjetosLG.Models
{
    [Table("ParticipanteProjeto")]
    public class ParticipanteProjeto
    {

        [Key]
        public int ParticipantePojetoId { get; set; }

        public Participante Participante { get; set; }

        public int ParticipanteId { get; set; }

        public Projeto Projeto { get; set; }
        public int ProjetoId { get; set; }



    }
}
