using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd_ProjetosLG.App_Code
{
    public class clsProjeto
    {

        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorProjeto { get; set; }
        public int Risco { get; set; }




    }
}