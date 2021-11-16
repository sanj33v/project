using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace App.DAL.DBHelper
{
   internal class DbHelper
    {

        static string MasterConnection = ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;
       

        internal static int ExceuteStoredPrcoReturnID(string commadName, SqlParameter[] parms,string dataBaseName)
        {
            int returnId = -1;
            string connectionString = "";

            if(string.IsNullOrEmpty(dataBaseName))
            {
                connectionString = MasterConnection;

            }
            else
            {
                var buiderString = new SqlConnectionStringBuilder(MasterConnection);
                buiderString.InitialCatalog = dataBaseName;
                connectionString = buiderString.ConnectionString;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = commadName;
                        cmd.Parameters.AddRange(parms);

                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        var result = cmd.ExecuteReader();

                        while (result.Read())
                            returnId = int.Parse(result["Id"].ToString());
                        result.Close();



                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }


                return returnId;

        }

        internal static DataSet GetStoredPrcoReturnbyDataSet(string commadName, SqlParameter[] parms, string dataBaseName)
        {
            
            string connectionString = "";
            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(dataBaseName))
            {
                connectionString = MasterConnection;

            }
            else
            {
                var buiderString = new SqlConnectionStringBuilder(MasterConnection);
                buiderString.InitialCatalog = dataBaseName;
                connectionString = buiderString.ConnectionString;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand())                    
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = commadName;
                        cmd.Parameters.AddRange(parms);

                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        var result = cmd.ExecuteNonQuery();
                        sda.Fill(dt);
                        con.Close();

                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }


           

        }

    }
}
