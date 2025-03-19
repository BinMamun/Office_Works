using Microsoft.Reporting.WebForms;
using ReportingServices.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;

namespace ProductManager.Pages
{
	public partial class ProductReport : Page
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
			var reportPath = ConfigurationManager.AppSettings["ReportPath"] + "ProductReport.rdlc";

			LocalReport localReport = new LocalReport
			{
				ReportPath = reportPath
			};
			localReport.DataSources.Clear();

			ReportDataSource rds = new ReportDataSource("ProductReportDataset", lst);
			localReport.DataSources.Add(rds);

			var reportName = "Product List";
			var rptName = new ReportParameter("RptName", reportName);
			var currentDate = new ReportParameter("Date", DateTime.UtcNow.AddHours(6).ToString("dd-MMM-yyyy hh:mm:ss tt"));

			localReport.SetParameters(new ReportParameter[] { rptName, currentDate });

			string mimeType, encoding, fileNameExtension;
			Warning[] warnings;
			string[] streamIds;

			byte[] pdfBytes = localReport.Render(
				"PDF", null, out mimeType, out encoding, out fileNameExtension,
				out streamIds, out warnings);

			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.ContentType = "application/pdf";
			HttpContext.Current.Response.AddHeader("Content-Disposition", $"inline; filename=ProductReport-{currentDate}.pdf");
			HttpContext.Current.Response.BinaryWrite(pdfBytes);
			HttpContext.Current.Response.End();
		}
	}
}