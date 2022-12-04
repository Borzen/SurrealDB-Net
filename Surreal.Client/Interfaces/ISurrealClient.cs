using Surreal.Client.Models;

namespace Surreal.Client.Interfaces
{
    public interface ISurrealClient
    {
        T ExecuteSqlQuery<T> (string sql);
        List<T> GetTableRecords<T> (string tableName);
        T GetTableRecord<T>(string tableName, string id);
        SurrealDBResult<T> CreateRecord<T>(string tableName, T data);
        SurrealDBResult<T> CreateRecord<T>(string tableName, string id, T data);
        SurrealDBResult DeleteRecord (string tableName, string id);
        SurrealDBResult DeleteAllTableRecords(string table);
        SurrealDBResult<T> UpdateRecord<T>(string tableName, string id, T data);

    }
}
