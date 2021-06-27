using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LG__Lorem_Ipsum_Inc_Projetos.Models
{
    [Table("Participantes")]
    public class Participante
    {

        public Participante()
        {
            ParticipanteProjeto = new Collection<ParticipanteProjeto>();
        }
       
        [Key]
        public int ParticipanteId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        public ICollection<ParticipanteProjeto> ParticipanteProjeto { get; set; }





       
    }
}
