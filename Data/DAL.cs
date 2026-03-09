using SwaggerCRUDWebAPI.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SwaggerCRUDWebAPI.Data
{
    public class DAL : IDAL
    {
        private readonly string _connectionString;

        // The runtime automatically injects IConfiguration here
        public DAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public List<Certification> ListCertfications()
        {
            using (SqlConnection objCon = new SqlConnection(_connectionString))
            {
                string objc = "select Code,[Name],ExamDate from Certification";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = objc;
                objCmd.Connection = objCon;


                SqlDataAdapter da = new SqlDataAdapter(objCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                var myData = ds.Tables[0].AsEnumerable().Select(r => new Certification
                {
                    Code = r.Field<string>("Code"),
                    Description = r.Field<string>("Name"),
                    ExamDate = r.Field<DateTime>("ExamDate")
                });
                var list = myData.ToList();

                return list;
            }
        }

        public void Save(Certification cert)
        {
            // Query to be executed
            string query = "Insert Into [Certification] (Code,[Name],ExamDate) " +
                               "VALUES (@code, @desc, @examdt) ";

            // instance connection and command
            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // add parameters and their values
                cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 10).Value = cert.Code;
                cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar, 500).Value = cert.Description;
                cmd.Parameters.Add("@examdt", System.Data.SqlDbType.Date).Value = cert.ExamDate;


                // open connection, execute command and close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Update(Certification cert)
        {
            // Query to be executed
            string query = "update Certification set name=@desc, ExamDate=@examdt where code=@code";


            // instance connection and command
            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // add parameters and their values
                cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 10).Value = cert.Code;
                cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar, 500).Value = cert.Description;
                cmd.Parameters.Add("@examdt", System.Data.SqlDbType.Date).Value = cert.ExamDate;


                // open connection, execute command and close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void Delete(string code)
        {
            // Query to be executed
            string query = "Delete from [Certification] where code=@code";

            // instance connection and command
            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // add parameters and their values
                cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 10).Value = code;

                // open connection, execute command and close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public Certification GetCertfication(string code)
        {
            using (SqlConnection objCon = new SqlConnection(_connectionString))
            {
                Certification? cert = null;
                string objc = "select Code,[Name],ExamDate from Certification where code=@code";

                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.AddWithValue("@code", code);
                objCmd.CommandText = objc;
                objCmd.Connection = objCon;

                SqlDataAdapter da = new SqlDataAdapter(objCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                var myData = ds.Tables[0].AsEnumerable().Select(r => new Certification
                {
                    Code = r.Field<string>("Code"),
                    Description = r.Field<string>("Name"),
                    ExamDate = r.Field<DateTime>("ExamDate")
                });
                if (myData != null && myData.Count() > 0)
                {
                    cert = myData.ToList()[0];

                }

                return cert;
            }
        }



    }
}
