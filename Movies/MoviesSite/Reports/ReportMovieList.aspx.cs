using Microsoft.Reporting.WebForms;
using MoviesSite.ReportModel;
using MoviesSite.ReportModel.MoviesReportDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesSite.Reports
{
    public partial class ReportMovieList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                this.ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://cibertec/ReportServer");
                this.ReportViewer1.ServerReport.ReportPath = "/Movies/MoviesReportList";



            }


            //if (!this.Page.IsPostBack)
            //{
            //    this.ReportViewer1.ProcessingMode = 
            //        Microsoft.Reporting.WebForms.ProcessingMode.Local;

            //    this.ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("~/Reports/MoviesReportClient.rdlc");                
                
            //    ReportDataSource rds = new ReportDataSource("MoviesDataSoruce"); 
                
            //    uv_Movies_defaultTableAdapter adp = new uv_Movies_defaultTableAdapter();                                               

            //    rds.Value = adp.GetData();

            //    this.ReportViewer1.LocalReport.DataSources.Add(rds);                
            //}
        }

        protected void ReportViewer1_ReportRefresh(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //var tb  = this.ReportViewer1.LocalReport.DataSources.ElementAt(0).Value 
            //    as MoviesReportDataSet.uv_Movies_defaultDataTable;


            //uv_Movies_defaultTableAdapter adp = new uv_Movies_defaultTableAdapter();

            //adp.ClearBeforeFill = true;

            //adp.Fill(tb);

            //this.ReportViewer1.DataBind(); 

        }

    }
}