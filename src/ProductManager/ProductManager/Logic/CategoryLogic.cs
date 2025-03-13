using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProductManager.Logic
{
	public class CategoryLogic
	{
		public static DataTable GetCategories()
		{
			return DbUtility.ExecuteReader("GetCategories");
		}
	}
}