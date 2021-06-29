using FrontEnd_ProjetosLG.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd_ProjetosLG
{
    public partial class CadastroProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddProjeto();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private async void AddProjeto()
        {
            string URI = Session["URI"].ToString();
            clsProjeto projeto = new clsProjeto();
            projeto.Nome = txtNome.Text;
            projeto.DataFim = Convert.ToDateTime(txtDataFim.Text);
            projeto.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
            projeto.Risco = Convert.ToInt32(dplRisco.SelectedValue);
            projeto.ValorProjeto = Convert.ToDecimal(txtValorProjeto.Text);

            using (var client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(projeto);
                var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

            }



        }
    }
}