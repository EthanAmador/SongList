using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase.Entity;
using Dapper;
using System.Data.SqlClient;

namespace Core.DataBase.Conexion
{
    public class AccesDataBase
    {
        /// <summary>
        ///  Execute stored procedure on the data base
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="p_nameProcedute">stored procedure name</param>
        /// <param name="p_Params">Diccionary parameters {Name,Value}</param>
        /// <returns></returns>
        public static IEnumerable<T> ExecuteProcedure<T>(string p_nameProcedute, IDictionary<string, object> p_Params /*params SqlParameter [] p_Params*/)
        {
            try
            {

                DynamicParameters _params = new DynamicParameters();
                ////_params.Add(name: "@iVch_name ", value: null, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
                foreach (KeyValuePair<string, object> item in p_Params)
                {
                    _params.Add(name: item.Key, value: item.Value);
                }
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SongList"].ConnectionString;
                    //"Server=DESKTOP-CTOHTEI;Database=Cosas;Trusted_Connection=True;";
                    connection.Open();
                    return connection.Query<T>(sql: p_nameProcedute, param: _params, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
