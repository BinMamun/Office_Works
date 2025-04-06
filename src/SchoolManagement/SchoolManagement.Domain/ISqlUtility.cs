using System.Data;

namespace SchoolManagement.Domain
{
    public interface ISqlUtility
    {
        int ExecuteNonQuery(string procedureName, params Object[] parameters);
        void ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters = null);
        DataTable ExecuteReader(string procedureName, params Object[] parameters);
        List<T> ExecuteReportReader<T>(string procedureName, Dictionary<string, object> parameters = null) where T : new();

        Task ExecuteStoredProcedureAsync(string procedureName, Dictionary<string, object> parameters = null);

        Task<(List<T> result, Dictionary<string, object> outValues)> QueryWithStoredProcedureAsync<T>(
    string procedureName, Dictionary<string, object> parameters = null) where T : new();
    }
}
