using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.MicrosoftAccount;
using PAP_Condominio.Models;
using PAP_Condominio.Relatorios.Moradores;

namespace PAP_Condominio.Relatorios
{
    public partial class frmRelatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
               CarregarRelatorio();
            


        }

        private void CarregarRelatorio()
        {


            //Pesquisar dados
            using (PAP_CondominioContext ctx = new PAP_CondominioContext())
            {
                var listaMoradores = ctx.Moradors.ToList();
                //preeencher dataSet

                //dsMoradores dataset = new dsMoradores();



                var query = from m in ctx.Moradors
                    join c in ctx.Condominios
                        on m.MoradorId equals c.CondominioId
                    select new
                    {
                        m.MoradorId,
                        m.NomeSobrenome,
                        m.Telefone,
                        m.Email,
                        m.Apartamento,
                        Condomino = c.Nome
                    };


                // Preencher dataSet
                dsMoradores dataset = new dsMoradores();

                //foreach (Produto p in listaProdutos)
                foreach (var morador in query)
                {
                    dataset._Moradores.AddMoradoresRow(
                        morador.MoradorId,
                        morador.NomeSobrenome,
                        morador.Telefone,
                        morador.Email,
                        morador.Apartamento,
                        //morador.CondominoId,
                        morador.Condomino





                        );
                }

            


                //Modo Processamento
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //Caminho do arquivo do relatorio (layout)
                ReportViewer1.LocalReport.ReportPath = @"Relatorios\rptMoradoresAnalitico.rdlc";
                //Limpando fontes de dados
                ReportViewer1.LocalReport.DataSources.Clear();
                //definir novas fontes de dados
                ReportViewer1.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WebForms.ReportDataSource("Moradores",(DataTable)dataset._Moradores ));



            }
        }


    }
}