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

namespace FrontEnd_ProjetosLG
{
    public partial class Home : System.Web.UI.Page
    {

        //string URI = "https://localhost:44394";
        //string URIPP = "https://localhost:44394";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllProjetos();

            }

        }

        private async void GetAllProjetos()
        {

            string URI = "https://localhost:44394/api/Projetos";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProjetoJsonString = await response.Content.ReadAsStringAsync();
                        gvProjetos.DataSource = JsonConvert.DeserializeObject<clsProjeto[]>(ProjetoJsonString).ToList();                                        

                        gvProjetos.DataBind();

                    }
                    else
                    {
                        //"Mensagem de erro;
                    }
                }
            }
        }

          
        private async void DeleteProjetos(int codProjeto)
        {
            string URI = "https://localhost:44394/api/Projetos";

            string URIPP = "https://localhost:44394/api/ParticipanteProjetos";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URIPP + "/" + Convert.ToInt32(codProjeto)))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        var ProjetoJsonString = await response.Content.ReadAsStringAsync();
                        var obj = JsonConvert.DeserializeObject<clsParticipante[]>(ProjetoJsonString);
                        if(obj != null)
                        {
                            client.BaseAddress = new Uri(URI);
                            HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", URI, codProjeto));
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                //Mensagem Excluido
                            }
                            else
                            {
                                //Mensagem Falha;
                            }
                        }
                        

                    }
                    else
                    {
                        MensagemErro();
                    }
                }



               
            }

            GetAllProjetos();
        }

        private async void DeleteParticipantes(int codParticipante)
        {
            string URI = "https://localhost:44394/api/Participantes";

            int idParticipante = codParticipante;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", URI, idParticipante));
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Mensagem Excluido
                }
                else
                {
                    //Mensagem Falha;
                }
            }

            GetAllProjetos();
        }

        protected async void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int customerId = Convert.ToInt32(gvProjetos.DataKeys[e.Row.RowIndex].Value.ToString());

                GridView gvParticipante = e.Row.FindControl("gvParticipantes") as GridView;
                string URI = "https://localhost:44394/api/ParticipanteProjetos";
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(URI + "/" + Convert.ToInt32(customerId)))
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

        protected void gvParticipantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }       

        protected void gvProjetos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Projetos")
            {                  
                int index = int.Parse((string)e.CommandArgument);
                string projetoId = gvProjetos.Rows[index].Cells[2].Text;
                Response.Redirect("SimularInvestimento.aspx?id=" + projetoId);
            }
            if (e.CommandName == "details")
            {
                int index = int.Parse((string)e.CommandArgument);
                string projetoId = gvProjetos.Rows[index].Cells[2].Text;
                Response.Redirect("ProjetosDetalhes.aspx?id=" + projetoId);
            }
            if (e.CommandName == "edit")
            {
                int index = int.Parse((string)e.CommandArgument);
                string projetoId = gvProjetos.Rows[index].Cells[2].Text;
                Response.Redirect("EditarProjeto?id=" + projetoId);
            }
            if (e.CommandName == "delete")
            {
                int index = int.Parse((string)e.CommandArgument);
                string projetoId = gvProjetos.Rows[index].Cells[2].Text;
                DeleteProjetos(index);
                               
            }
            
        }

        public void MensagemErro()
        {

            //Mensagem de erro
            string message = "É necessario excluir o participante vinculado ao Projeto";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(message);

            sb.Append("')};");

            sb.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }




    }
}