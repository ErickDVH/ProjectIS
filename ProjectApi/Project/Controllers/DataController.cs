using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Project.Controllers
{
    public class DataController : ApiController
    {

        string connection_string = Properties.Settings.Default.connStr;
        /*
        // GET api/<controller>
        [Route("api/application/{applicationId}/data")]
        public IEnumerable<Data> GetAllData(string applicationId)
        {
            List<Data> datas = new List<Data>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "SELECT * FROM Data WHERE Parent = " +
                "(SELECT id FROM dbo.Application WHERE Name = @applicationId);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@applicationId", applicationId);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data newData = new Data()
                    {
                        Id = (int)reader["Id"],
                        Content = (string)reader["Content"],
                        Creation_dt = (DateTime)reader["Creation_dt"],
                        Parent = (int)reader["Parent"],
                        Res_type = (string)reader["Res_type"]
                    };

                    datas.Add(newData);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return datas;
        }

        // GET api/<controller>/5
        [Route("api/application/{applicationId}/data/{id}")]
        public IHttpActionResult GetDataById(string applicationId, string dataId)
        {
            Data data = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "SELECT * FROM Module WHERE Name=@dataId AND Parent = " +
                                    "(SELECT Id FROM dbo.Application WHERE Name = @applicationId);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@appplicationId", applicationId);
                cmd.Parameters.AddWithValue("@dataId", dataId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = new Data()
                    {
                        Id = (int)reader["Id"],
                        Content = (string)reader["Content"],
                        Creation_dt = (DateTime)reader["Creation_dt"],
                        Parent = (int)reader["Parent"],
                        Res_type = (string)reader["Res_type"]
                    };
                }

                reader.Close();
                conn.Close();

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                return NotFound();
            }
        }
        */
        
        // POST api/<controller>
        [Route("api/application/{applicationId}/data")]
        [HttpPost]
        public IHttpActionResult Post(string applicationId, [FromBody] Data data)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "INSERT INTO Data VALUES(@Content, @Creation_dt, @Parent, @Res_type)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int parent = getApplicationId(applicationId);
                cmd.Parameters.AddWithValue("@Content", data.Content);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Parent", parent);
                cmd.Parameters.AddWithValue("@Res_type", data.Res_type);

                int num_records = cmd.ExecuteNonQuery();

                conn.Close();

                if (num_records > 0)
                {
                    return Ok();
                }
                return InternalServerError();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                return InternalServerError();
            }
        }
        /*
        // PUT api/<controller>/5
        [Route("api/application/{applicationId}/data/{id}")]
        public IHttpActionResult Put(string applicationId, string dataId, [FromBody] Data data)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "UPDATE Data SET Content = @Content, Creation_dt = @Creation_dt, Parent = @Parent, Res_type = @Res_type WHERE Id=@dataId AND Parent = " +
                "(SELECT Id from dbo.Application WHERE Name = @applicationID);";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Content", data.Content);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Parent", data.Parent);
                cmd.Parameters.AddWithValue("@Res_type", data.Res_type);
                cmd.Parameters.AddWithValue("@dataId", dataId);
                cmd.Parameters.AddWithValue("@applicationId", applicationId);

                int num_records = cmd.ExecuteNonQuery();

                conn.Close();

                if (num_records > 0)
                {
                    return Ok();
                }
                return InternalServerError();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                return NotFound();
            }
        }*/

        // DELETE api/<controller>/5
        [Route("api/application/{applicationId}/data/{id}")]
        public IHttpActionResult Delete(string applicationId, string dataId)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "DELETE FROM Data WHERE Id = @dataId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@dataId", dataId);
                cmd.Parameters.AddWithValue("@applicationId", applicationId);

                int num_records = cmd.ExecuteNonQuery();

                conn.Close();

                if (num_records > 0)
                {
                    return Ok();
                }
                return InternalServerError();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                return NotFound();
            }
        }

        private int getApplicationId(string name)
        {
            SqlConnection conn = null;
            int id;
            conn = new SqlConnection(connection_string);
            conn.Open();
            string query = "SELECT Id from dbo.Application WHERE Name = @Name;";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Name", name);
            id = (int)cmd.ExecuteScalar();
            conn.Close();

            return id;
        }
    }
}