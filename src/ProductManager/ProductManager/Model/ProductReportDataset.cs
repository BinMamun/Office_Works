using ReportingServices.Model;
using System.Collections.Generic;

namespace ProductManager.Model
{
	public class ProductReportDataset
	{
        public static List<ProductReportModel> GetProductReportData()
        {
            return DbUtility.ExecuteReportReader<ProductReportModel>("GetProducts");
        }
    }
}