using Dapper;
using DapperDemo.Core.Entities;
using DapperDemo.Core.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DapperDemo.Core.DataAccess.Dapper
{
    public class DpEntityRepositoryBase<T> : EntityHelper<T>, IEntityRepository<T>
        where T : class, IEntity, new()
    {
        public SqlConnection _connectionString { get; set; }
        public DpEntityRepositoryBase()
        {
            _connectionString = Connection;
        }

        public IEnumerable<T> GetAll(List<string> columnNames = null)
        {
            using (var connection = _connectionString)
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string query = string.Empty;
                if (columnNames.Count == 0)
                {
                    query = $"SELECT * FROM {tableName}";
                }
                else
                {
                    query = $"SELECT * FROM {tableName} Where";
                    foreach (var item in columnNames)
                    {
                        query += $"{keyColumn} = {item}";
                    }
                }

                return connection.Query<T>(query);
            }
        }

        public T Get(List<string> columnNames)
        {
            using (var connection = _connectionString)
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string query = string.Empty;
                if (columnNames.Count == 0)
                {
                    query = $"SELECT * FROM {tableName}";
                }
                else
                {
                    query = $"SELECT * FROM {tableName} Where";
                    foreach (var item in columnNames)
                    {
                        query += $"{keyColumn} = {item}";
                    }
                }

                return connection.Query<T>(query).FirstOrDefault();
            }
        }

        public T Add(T entity)
        {
            using (var connection = _connectionString)
            {
                string tableName = GetTableName();
                string columns = GetColumns(excludeKey: true);
                string properties = GetPropertyNames(excludeKey: true);
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";

                var result = connection.Query<T>(query, entity);
                return result != null ? result.FirstOrDefault() : new T();
            }
        }

        public T Update(T entity)
        {
            using (var connection = _connectionString)
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string keyProperty = GetKeyPropertyName();

                StringBuilder query = new StringBuilder();
                query.Append($"UPDATE {tableName} SET ");

                foreach (var property in GetProperties(true))
                {
                    var columnAttr = property.GetCustomAttribute<ColumnAttribute>();

                    string propertyName = property.Name;
                    string columnName = columnAttr.Name;

                    query.Append($"{columnName} = @{propertyName},");
                }

                query.Remove(query.Length - 1, 1);

                query.Append($" WHERE {keyColumn} = @{keyProperty}");

                var result = connection.Query<T>(query.ToString(), entity);
                return result != null ? result.FirstOrDefault() : new T();
            }
        }

        public bool Delete(T entity)
        {
            using (var connection = _connectionString)
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string keyProperty = GetKeyPropertyName();
                string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";

                var result = connection.Execute(query, entity);
                return result > 0 ? true : false;
            }
        }

        public T ExecuteStoreProcedure(string procedureName, object parameters = null)
        {
            using (var connection = _connectionString)
            {
                return connection.Query(procedureName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<T> ExecuteStoreProcedureToList(string procedureName, object parameters = null)
        {
            using (var connection = _connectionString)
            {
                return connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
