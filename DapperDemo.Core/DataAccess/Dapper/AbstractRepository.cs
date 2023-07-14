using DapperDemo.Core.Utilities.Configuration;
using System.Data.SqlClient;

namespace DapperDemo.Core.DataAccess.Dapper
{
    public abstract class AbstractRepository
    {
        protected SqlConnection Connection 
        {
            get
            {
                return new SqlConnection(CoreConfig.GetConnectionString("Default"));
            }
        }
    }
}
