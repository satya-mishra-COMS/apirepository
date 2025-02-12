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
    public class CommonUtility : ICommonUtility
    {
        public void executeStoredProcedure(string SPName, SqlParameter parameters, string connectionStringName)
        {
            using (MySqlConnection con = new MySqlConnection(connectionStringName))
            {
                using (MySqlCommand cmd = new MySqlCommand(SPName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.Add(parameters);

                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public DataSet executeReaderProcedure(string SPName, List<MySqlParameter> parameters, string connectionStringName)
        {
            var ds = new DataSet();
            using (MySqlConnection con = new MySqlConnection(connectionStringName))
            {
                using (MySqlCommand cmd = new MySqlCommand(SPName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;



                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }


                    }
                    con.Open();
                    var adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    // reader = cmd.ExecuteReader();
                    // reader.Close();
                }
            }
            return ds;
        }
        public string EncodePasswordToBase64(string password)

        {
            byte[] encData_byte = new byte[password.Length];

            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);

            string encodedData = Convert.ToBase64String(encData_byte);

            return encodedData;



        }

        public string DecodePasswordToBase64(string foprmBase64password)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(foprmBase64password);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(base64EncodedBytes));
            string encodedData = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            return encodedData;



        }
        public  List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();
        }




    }
}

