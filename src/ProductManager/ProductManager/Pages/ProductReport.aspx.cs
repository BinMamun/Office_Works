using Microsoft.Reporting.WebForms;
using ReportingServices.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManager.Pages
{
	public partial class ProductReport : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PrintReport("Product Report");
			}
		}

		private List<ProductReportModel> GetProductReportData()
		{
			return DbUtility.ExecuteReportReader<ProductReportModel>("GetProducts");
		}

		private void PrintReport(string reportName)
		{
			var lst = GetProductReportData();

			var reportPath = ConfigurationManager.AppSettings["ReportPath"];
			rvProducts.LocalReport.ReportPath = reportPath + "ProductReport.rdlc";
			rvProducts.LocalReport.DataSources.Clear();

			var rptName = new ReportParameter("ReportName", reportName);
			var currentDate = new ReportParameter("Date", DateTime.UtcNow.ToString());
			ReportDataSource rds = new ReportDataSource("ProductReportDataset", lst);
			rvProducts.LocalReport.DataSources.Add(rds);
			rvProducts.LocalReport.SetParameters(new ReportParameter[] { rptName, currentDate });
			rvProducts.LocalReport.Refresh();
		}
	}
}