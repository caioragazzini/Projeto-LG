using Amazon.S3;
using FrontEnd_ProjetosLG.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FrontEnd_ProjetosLG
{
    public partial class SimularInvestimento : System.Web.UI.Page
    {
        double valoRetorno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int projetoId = Convert.ToInt32(Request.QueryString["id"]);

                GetProjetosID(projetoId);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txtValorInvestimento.Text != "")
            {
                double valorInvestimento = Convert.ToDouble(txtValorInvestimento.Text);


                string strvalorProjeto = (lblValor.Text);
                string x = strvalorProjeto.Substring(1);

                double valorProjeto = Convert.ToDouble(x);

                if (dplRisco.SelectedValue == "0")
                {
                    valoRetorno = valorInvestimento * 0.05;
                }
                if (dplRisco.SelectedValue == "1")
                {
                    valoRetorno = valorInvestimento * 0.10;
                }
                if (dplRisco.SelectedValue == "2")
                {
                    valoRetorno = valorInvestimento * 0.20;
                }

                lblRetorno.Text = valoRetorno.ToString("C");

                if (valorInvestimento < valorProjeto)
                {
                    MensagemErro();

                }
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
                      
                        lblNome.Text = obj.Nome;
                        lblValor.Text = obj.ValorProjeto.ToString("C");
                    }
                    else
                    {

                    }
                }
            }

        }




        public void MensagemErro()
        {

            //Mensagem de erro
            string message = "O valor do investimento não pode ser menor que o do projeto";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(message);

            sb.Append("')};");

            sb.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}