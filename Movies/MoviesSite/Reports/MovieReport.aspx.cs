using MoviesSite.MoviesDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesSite.Reports
{
    public partial class MovieReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote; 
            //this.ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://devserver/ReportServer_SQLEXPRESS2014");
            //this.ReportViewer1.ServerReport.ReportPath = "/Movies/MovieReport";            

            
            if (!Page.IsPostBack)
            {
                //this.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //this.ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("~/Reports/MoviesReportClient.rdlc");
                //var ds = new Microsoft.Reporting.WebForms.ReportDataSource("MoviesDataSoruce");
                //var adpT = new MoviesTableAdapter();
                //var t = adpT.GetData();
                //t.Rows[0]["Title"] = t.Rows[0]["Title"] + DateTime.Now.ToLongTimeString();
                //ds.Value = t;
                //this.ReportViewer1.LocalReport.DataSources.Add(ds);                
            }
            

        }
        

        protected void ReportViewer1_ReportRefresh1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var t =  this.ReportViewer1.LocalReport.DataSources.ElementAt(0).Value as MoviesDBDataSet.MoviesDataTable;
            //var adpT = new MoviesTableAdapter();
            //adpT.ClearBeforeFill = true;
            //adpT.Fill(t);
            //t.Rows[0]["Title"] = t.Rows[0]["Title"] + DateTime.Now.ToLongTimeString();
            //this.ReportViewer1.DataBind();
        }
    }
}