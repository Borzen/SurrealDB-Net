using Surreal.Client.Models;

namespace Surreal.Client.Interfaces
{
    public interface ISurrealClient
    {
        List<T> ExecuteSqlQuery<T> (string sql);
        SurrealDBResults<T> GetTableRecords<T> (string tableName);
        SurrealDBResult<T> GetTableRecord<T>(string tableName, string id);
        SurrealDBResult<T> CreateRecord<T>(string tableName, T data);
        SurrealDBResult<T> CreateRecord<T>(string tableName, string id, T data);
        SurrealDBResult DeleteRecord (string tableName, string id);
        SurrealDBResult DeleteAllTableRecords(string table);
        SurrealDBResult<T> UpdateRecord<T>(string tableName, string id, T data);

    }
}
