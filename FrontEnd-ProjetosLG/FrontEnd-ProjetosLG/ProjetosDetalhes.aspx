<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjetosDetalhes.aspx.cs" Inherits="FrontEnd_ProjetosLG.ProjetosDetalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <div>
        <div>
           <h1><strong>Projeto : <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label> </strong></h1>
        </div>
    </div>
    <table>
        <tr>
           
        </tr>
        <tr>
            <td>Data Inicio:
            </td>
            <td>
                <asp:Label ID="lblDataInicio" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Data Fim:
            </td>
            <td>
                <asp:Label ID="lblDataFim" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Valor do Projeto:
            </td>
            <td>
                <asp:Label ID="lblValor" runat="server" Text="Label"></asp:Label>
            </td>

             <td>Valor do Investimento:

            </td>
            <td>
                <asp:Label ID="lblValorInvestimento" runat="server" Text="Label"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>Risco:
            </td>
            <td>
                <asp:Label ID="lblRisco" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

    </table>

    <div>
        <h2>Participantes do Projeto</h2>
    </div>
    <asp:GridView ID="gvParticipante" runat="server" AutoGenerateColumns="False"
        CssClass="table table-striped table-bordered table-condensed" DataKeyNames="ParticipanteId" Width="100%">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
        </Columns>
    </asp:GridView>



</asp:Content>
