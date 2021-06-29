using FrontEnd_ProjetosLG.App_Code;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System;
using System.Data;
using System.Threading.Tasks;

namespace FrontEnd_ProjetosLG
{
    public partial class ProjetosDetalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int projetoId = Convert.ToInt32(Request.QueryString["id"]);
                GetProjetosID(projetoId);
                
            }
        }

        public async void GetProjetosID(int id)
        {
            string URI = "https://localhost:44394/api/Projetos";
           
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI + "/" + Convert.ToInt32(id)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                       
                        var ProjetoJsonString = await response.Content.ReadAsStringAsync();
                        var obj = JsonConvert.DeserializeObject<clsProjeto>(ProjetoJsonString);

                        GetAllParticipanteID(obj.ProjetoId);

                        lblNome.Text = obj.Nome;
                        lblDataFim.Text = obj.DataFim.ToString();
                        lblDataInicio.Text = obj.DataInicio.ToString();
                       
                     
                        double valorInvestimento = Convert.ToDouble(obj.ValorProjeto);
                        if(obj.Risco == 0)
                        {
                            valorInvestimento = valorInvestimento * 0.05;
                        }
                        if (obj.Risco == 1)
                        {
                            valorInvestimento = valorInvestimento * 0.10;
                        }
                        if (obj.Risco == 2)
                        {
                            valorInvestimento = valorInvestimento * 0.20;
                        }

                        lblValor.Text = obj.ValorProjeto.ToString("C");
                        lblValorInvestimento.Text = valorInvestimento.ToString("C");
                        switch (obj.Risco)
                        {
                            case 0:
                                lblRisco.Text = "Baixo";
                                break;
                            case 1:
                                lblRisco.Text = "Médio";
                                break;
                            case 2:
                                lblRisco.Text = "Alto";
                                break;
                        }
                    }
                    else
                    {

                    }
                }
            }

        }


        private async void GetAllParticipanteID(int id)
        {          

            string URI = "https://localhost:44394/api/ParticipanteProjetos";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI + "/" + Convert.ToInt32(id)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProjetoJsonString = await response.Content.ReadAsStringAsync();
                        gvParticipante.DataSource = JsonConvert.DeserializeObject<clsParticipante[]>(ProjetoJsonString).ToList();
                        gvParticipante.DataBind();
                    }
                    else
                    {
                        //"Mensagem de erro;
                    }
                }
            }
        }



    }
}



