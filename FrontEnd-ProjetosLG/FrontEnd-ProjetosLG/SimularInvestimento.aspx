<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimularInvestimento.aspx.cs" Inherits="FrontEnd_ProjetosLG.SimularInvestimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div>
        <div>
            <h1><strong>Projeto :
                <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label>
            </strong></h1>
        </div>
    </div>
    <table>
        <tr>
            <td>Valor do Investimento:
            </td>
            <td>
                <asp:TextBox ID="txtValorInvestimento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Valor do Projeto:
            </td>
            <td>
                <asp:Label ID="lblValor" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>

         <tr>
            <td>Valor de Retorno:
            </td>
            <td>
                <asp:Label ID="lblRetorno" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td>Risco:
            </td>
            <td>
                <asp:DropDownList ID="dplRisco" runat="server">
                    <asp:ListItem Value="0">Baixo</asp:ListItem>
                    <asp:ListItem Value="1">Médio</asp:ListItem>
                    <asp:ListItem Value="2">Alto</asp:ListItem>
                </asp:DropDownList>


            </td>
        </tr>
    </table>

    <asp:Button ID="Button1" runat="server" Text="Calcular Investimento" OnClick="Button1_Click" />
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />






</asp:Content>
