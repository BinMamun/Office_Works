using System.Data;

namespace SchoolManagement.Domain
{
    public interface ISqlUtility
    {
        int ExecuteNonQuery(string procedureName, params Object[] parameters);
        void ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters = null);
        DataTable ExecuteReader(string procedureName, params Object[] parameters);
        List<T> ExecuteReportReader<T>(string procedureName, Dictionary<string, object> parameters = null)where T : new();
    }
}
