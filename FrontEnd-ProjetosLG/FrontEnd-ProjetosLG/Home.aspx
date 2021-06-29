<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FrontEnd_ProjetosLG.Home" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <p>
        <asp:LinkButton ID="LinkButton1" PostBackUrl="~/CadastroProjeto.aspx" runat="server"> Adicionar Novo Projeto</asp:LinkButton>
    </p>


    <asp:GridView ID="gvProjetos" runat="server" AutoGenerateColumns="False"
        CssClass="table table-striped table-bordered table-condensed" DataKeyNames="ProjetoId"
        Width="100%"
        OnRowDataBound="OnRowDataBound"
        OnRowCommand="gvProjetos_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt="" style="cursor: pointer" src="../Images/plus.png" temp_src="../Images/plus.png" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvParticipantes" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-condensed">
                            <Columns>
                                <asp:ButtonField CommandName="Participante" Text="Button" />

                                <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Nome" HeaderText="Nome" />

                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:HiddenField ID="IsExpanded" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Projetos" Text="Simular Investimento" />
            <asp:BoundField DataField="ProjetoId" HeaderText="Cod" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="DataInicio" HeaderText="Data Inicio" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="DataFim" HeaderText="Data Fim" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="ValorProjeto" HeaderText="Valor Projeto" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Risco" HeaderText="Risco" />

            <asp:ButtonField CommandName="edit" Text="Editar" DataTextField="ProjetoId" />
            <asp:ButtonField CommandName="details" Text="Detalhes" />
            <asp:ButtonField CommandName="delete" Text="Deletar" />





        </Columns>
    </asp:GridView>














</asp:Content>
