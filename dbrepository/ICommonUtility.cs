using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbrepository
{
    public interface ICommonUtility
    {
        void executeStoredProcedure(string SPName, SqlParameter parameters, string connectionStringName);
        DataSet executeReaderProcedure(string SPName, List<MySqlParameter> parameters, string connectionStringName);
        string EncodePasswordToBase64(string password);
        string DecodePasswordToBase64(string foprmBase64password);
        List<T> ConvertToList<T>(DataTable dt);
    }
}
