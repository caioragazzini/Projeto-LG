using FrontEnd_ProjetosLG.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd_ProjetosLG
{
    public partial class EditarProjeto : System.Web.UI.Page
    {
        int projetoId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                projetoId = Convert.ToInt32(Request.QueryString["id"]);
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

                        txtNome.Text = obj.Nome;
                        txtDataFim.Text = obj.DataFim.ToString();
                        txtDataInicio.Text = obj.DataInicio.ToString();
                        dplRisco.SelectedItem.Value = obj.Risco.ToString();
                                               
                    }
                    else
                    {

                    }
                }
            }

        }

        private async void UpdateProjetos(clsProjeto projetos)
        {
            string URI = "https://localhost:44394/api/Projetos";
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URI + "/" + Convert.ToInt32(projetos.ProjetoId), projetos);
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Mensagem Atualizado
                }
                else
                {
                    //Mensagem Falha
                }
            }
            
        }      

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Obtem cada valor único do DataKeyNames
            clsProjeto projeto = new clsProjeto();
            projeto.ProjetoId = projetoId;
             projeto.Nome =txtNome.Text;
            projeto.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
            projeto.DataFim = Convert.ToDateTime(txtDataFim.Text);
            projeto.ValorProjeto = Convert.ToDecimal(txtValorProjeto.Text);
            projeto.Risco = Convert.ToInt32(dplRisco.SelectedValue);

            UpdateProjetos(projeto);

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}