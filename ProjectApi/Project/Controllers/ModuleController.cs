using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Project.Controllers
{
    public class ModuleController : ApiController
    {
        string connection_string = Properties.Settings.Default.connStr;

        private List<Module> modules;

        // GET All api/<controller>
        [Route("api/modules")]
        public IEnumerable<Module> GetAllModules()
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM modules";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Module newModule = new Module()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Creation_dt = (DateTime)reader["Creation_dt"],
                        Parent = (int)reader["Parent"]
                    };

                    this.modules.Add(newModule);
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

            return this.modules;
        }

        // GET Id api/<controller>/5
        [Route("api/modules/{id}")]
        public IHttpActionResult GetModuleById(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM modules WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                if (this.modules[0] == null)
                {
                    return NotFound();

                }
                return Ok(modules);

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
        [Route("api/modules")]
        [HttpPost]
        public IHttpActionResult StoreModule(Module module)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "INSERT INTO modules (Name, Creation_dt, Parent) VALUES (@name, @creation_dt, @parent)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", module.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", module.Parent);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    return Ok();
                }
                return NotFound();
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

        // PUT api/<controller>/5
        [Route("api/modules/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateModule(Module module)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "UPDATE modules SET Name=@name, Creation_dt=@creation_dt, Parent=@parent WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", module.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", module.Parent);
                cmd.Parameters.AddWithValue("@id", module.Id);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    return Ok();
                }
                return NotFound();
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
        [Route("api/modules/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteModule(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "DELETE FROM modules WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    return Ok();
                }
                return NotFound();
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

    }
}