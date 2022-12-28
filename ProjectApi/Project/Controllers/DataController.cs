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

        //Teste teste teste

        // GET api/<controller>
        [Route("api/data/")]
        public IEnumerable<Data> GetAllData()
        {
            List<Data> datas = new List<Data>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "SELECT * FROM Data";
                SqlCommand cmd = new SqlCommand(sql, conn);

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
        [Route("api/data/{id:int}")]
        public IHttpActionResult GetProductById(int id)
        {
            Data data = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "SELECT * FROM Data WHERE Id = @IdData";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdData", id);

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

        
        // POST api/<controller>
        [Route("api/data/")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Data data)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "INSERT INTO Data VALUES(@Content, @Creation_dt, @Parent, @Res_type)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Content", data.Content);
                cmd.Parameters.AddWithValue("@Creation_dt", data.Creation_dt);
                cmd.Parameters.AddWithValue("@Parent", data.Parent);
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

        // PUT api/<controller>/5
        [Route("api/data/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Data data)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "UPDATE Data SET Content = @Content, Creation_dt = @Creation_dt, Parent = @Parent, Res_type = @Res_type WHERE Id = @IdData";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Content", data.Content);
                cmd.Parameters.AddWithValue("@Creation_dt", data.Creation_dt);
                cmd.Parameters.AddWithValue("@Parent", data.Parent);
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
                return NotFound();
            }
        }

        // DELETE api/<controller>/5
        [Route("api/data/{id}")]
        public IHttpActionResult Delete(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "DELETE FROM Data WHERE Id = @IdData";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdData", id);

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
    }
}