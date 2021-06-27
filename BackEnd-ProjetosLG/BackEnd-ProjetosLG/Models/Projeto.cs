using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_ProjetosLG.Models
{
    [Table("Projetos")]
    public class Projeto
    {

        public Projeto()
        {
            ParticipanteProjeto = new Collection<ParticipanteProjeto>();
        }

        [Key]
        public int ProjetoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicio { get; set; }
        
        [Required]
        [Display(Name = "Data Fim")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataFim { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal ValorProjeto { get; set; }

        [Required]
        public int Risco { get; set; }

        public ICollection<ParticipanteProjeto> ParticipanteProjeto { get; set; }

    }
}
