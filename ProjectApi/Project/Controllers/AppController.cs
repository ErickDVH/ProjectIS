using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;

namespace Project.Controllers
{
    public class AppController : ApiController
    {
        string connection_string = Properties.Settings.Default.connStr;

        // GET api/<controller> 
        [Route("api/Application/")]
        public IEnumerable<Application> GetAllData()
        {
            List<Application> datas = new List<Application>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "SELECT * FROM Application";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Application newApp = new Application()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Creation_dt = (DateTime)reader["Creation_dt"],

                    };

                    datas.Add(newApp);
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
        [Route("api/Application/{id}")]
        public IHttpActionResult GetApplicationById(string id)
        {
            Data data = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "SELECT * FROM Application WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdApplication", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = new Data()
                    {
                        Id = (int)reader["Id"],
                        Content = (string)reader["Content"],
                        Creation_dt = (DateTime)reader["Creation_dt"]
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
        [Route("api/Application/")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Application app)
        {
            SqlConnection conn = null;
            try
            {

                // Create the XML document to send
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("root",
                        new XElement("Name", app.Name),
                        new XElement("Creation_dt", app.Creation_dt)
                        )
                );

                // Convert the XML document to a string
                string xmlString = doc.ToString();

                // Encode the XML string in a UTF-8 byte array
                byte[] data = Encoding.UTF8.GetBytes(xmlString);


                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "INSERT INTO Application VALUES(@Name, @Creation_dt)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Name", app.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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
        [Route("api/Application/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Data data)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "UPDATE Data SET Name = @Name, Creation_dt = @Creation_dt WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", data.Content);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));



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
        [Route("api/Application/{id}")]
        public IHttpActionResult Delete(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();

                string sql = "DELETE FROM Data WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", id);

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