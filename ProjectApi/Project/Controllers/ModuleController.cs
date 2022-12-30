using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml;
namespace Project.Controllers
{
    public class ModuleController : ApiController
    {
        string connection_string = Properties.Settings.Default.connStr;

        private List<Module> modules;

        // GET All api/<controller>
        [Route("api/application/{applicationId}/module")]
        public IEnumerable<Module> GetAllModules(string applicationId)
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM Module WHERE Parent = " +
                "(SELECT id FROM dbo.Application WHERE Name = @applicationId);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@applicationId", applicationId);


                SqlDataReader reader = cmd.ExecuteReader();

                
                // Create an XML document to store the results
                var doc = new XmlDocument();
                var root = doc.CreateElement("Results");
                doc.AppendChild(root);

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
                    
                    
                    var element = doc.CreateElement("Result");
                    element.SetAttribute("ID", reader["Id"].ToString());
                    element.SetAttribute("Name", reader["Name"].ToString());
                    element.SetAttribute("Creation date", reader["Creation_dt"].ToString());
                    element.SetAttribute("Parent", (string)reader["Parent"]);

                    root.AppendChild(element);
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
        [Route("api/application/{applicationId}/module/{moduleId}")]
        public IHttpActionResult GetModuleById(string applicationId, string moduleId)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM Module WHERE Name=@moduleId AND Parent = "+
                                    "(SELECT Id FROM dbo.Application WHERE Name = @applicationId);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@appplicationId", applicationId);
                cmd.Parameters.AddWithValue("@moduleId", moduleId);

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
        [Route("api/application/{applicationId}/module")]
        [HttpPost]
        public IHttpActionResult StoreModule(string applicationId,Module module)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "INSERT INTO modules (Name, Creation_dt, Parent) VALUES (@name, @creation_dt, @parent)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int parent = getApplicationId(applicationId);
                cmd.Parameters.AddWithValue("@name", module.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", parent);

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
        [Route("api/application/{applicationId}/module/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateModule(string applicationId, string moduleId,Module module)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "UPDATE modules SET Name=@name, Creation_dt=@creation_dt, Parent=@parent WHERE Id=@moduleId AND Parent = " +
                "(SELECT Id from dbo.Application WHERE Name = @applicationID);"; 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", module.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", module.Parent);
                cmd.Parameters.AddWithValue("@moduleId", moduleId);
                cmd.Parameters.AddWithValue("@applicationId", applicationId);


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
        [Route("api/application/{applicationId}/module/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteModule(string applicationId, string moduleId)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "DELETE FROM modules WHERE Id=@moduleId AND Parent=@applicationId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@moduleId", moduleId);
                cmd.Parameters.AddWithValue("@applicationId", applicationId);


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