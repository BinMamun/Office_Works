using Microsoft.Reporting.WebForms;
using ReportingServices.Model;
using System;
using System.Collections.Generic;
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
				PrintReport();
			}
		}

		private List<ProductReportModel> GetProductReportData()
		{
			return DbUtility.ExecuteReportReader<ProductReportModel>("GetProducts");
		}

		private void PrintReport()
		{
			var lst = GetProductReportData();
			rvProducts.LocalReport.ReportPath = @"C:\Abdullah_Practice\Office_Works\src\ProductManager\ReportingServices\Reports\ProductReport.rdlc";
			rvProducts.LocalReport.DataSources.Clear();

			ReportDataSource rds = new ReportDataSource("ProductReportDataset", lst);
			rvProducts.LocalReport.DataSources.Add(rds);
			//rvProducts.LocalReport.SetParameters()
			rvProducts.LocalReport.Refresh();
		}
	}
}