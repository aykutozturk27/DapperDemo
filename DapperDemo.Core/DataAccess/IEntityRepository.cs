using DapperDemo.Core.Entities;

namespace DapperDemo.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll(List<string> columnNames = null);
        T Get(List<string> columnNames);
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
        T ExecuteStoreProcedure(string procedureName, object parameters = null);
        IEnumerable<T> ExecuteStoreProcedureToList(string procedureName, object parameters = null);
    }
}
