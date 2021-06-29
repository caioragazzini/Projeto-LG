<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarProjeto.aspx.cs" Inherits="FrontEnd_ProjetosLG.EditarProjeto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <div class="container">
        <h1>Editar Projeto</h1>
          <fieldset>
             <ul  class="divlabel">
                <li>
                  Nome:
                     <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </li>
                <li>
                   Data Inicio: 
                     <asp:TextBox ID="txtDataInicio" runat="server"></asp:TextBox>
                </li>

                <li>
                  Data Fim:
                     <asp:TextBox ID="txtDataFim" runat="server"></asp:TextBox>
                </li>
              
                <li>
                 Valor Projeto:
                     <asp:TextBox ID="txtValorProjeto" runat="server"></asp:TextBox>
                </li>
                   <li>
                  Risco:
                       <asp:DropDownList ID="dplRisco" runat="server">
                           <asp:ListItem>0</asp:ListItem>
                           <asp:ListItem>1</asp:ListItem>
                           <asp:ListItem>2</asp:ListItem>
                       </asp:DropDownList>                          
                </li>               
                <li>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEdit_Click" />
                     <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                </li>
            </ul>
        </fieldset>


    
    </div>







</asp:Content>
