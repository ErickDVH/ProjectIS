using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Project.Controllers
{
    public class SubscriptionController : ApiController
    {

        string connection_string = Properties.Settings.Default.connStr;
        private List<Subscription> subscriptions;
        
        public SubscriptionController()
        {
            subscriptions = new List<Subscription>();
        }
        /*
        [Route("api/application/{applicationId}/subscription")]
        public IEnumerable<Subscription> GetAllSubscriptions(string applicationId)
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM Subscription WHERE Parent = " +
                "(SELECT id FROM dbo.Application WHERE Name = @applicationId);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@applicationId", applicationId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subscription newSubscription = new Subscription()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Creation_dt = (DateTime)reader["Creation_dt"],
                        Parent = (int)reader["Parent"],
                        Event = (string)reader["Event"],
                        EndPoint = (string)reader["EndPoint"]
                    };

                    this.subscriptions.Add(newSubscription);
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

            return new List<Subscription>(subscriptions);
        }

        [Route("api/application/{applicationId}/subscription/{id}")]
        public IHttpActionResult GetSubscriptionById(string applicationId, string subscriptionId)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM subscription WHERE Name=@subscriptionId AND Parent = " +
                                    "(SELECT Id FROM dbo.Application WHERE Name = @applicationId);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@appplicationId", applicationId);
                cmd.Parameters.AddWithValue("@subscriptionId", subscriptionId);

                if (this.subscriptions[0] == null)
                {
                    return NotFound();

                }
                return Ok(subscriptions);

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

        [Route("api/application/{applicationId}/subscription")]
        [HttpPost]
        public IHttpActionResult StoreSubscription(string applicationId, Subscription subscription)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "INSERT INTO subscription (Name, Creation_dt, Parent, Event, Endpoint) VALUES (@name, @creation_dt, @parent, @event, @endpoint)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int parent = getApplicationId(applicationId);
                cmd.Parameters.AddWithValue("@name", subscription.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", parent);
                cmd.Parameters.AddWithValue("@event", subscription.Event);
                cmd.Parameters.AddWithValue("@endpoint", subscription.EndPoint);

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
        /*
        [Route("api/application/{applicationId}/subscription/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateSubscription(string applicationId, string subscriptionId, Subscription subscription)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "UPDATE subscription SET Name=@name, Creation_dt=@creation_dt, Parent=@parent, Event = @event, EndPoint = @endpoint WHERE Id=@subscription AND Parent = " +
                "(SELECT Id from dbo.Application WHERE Name = @applicationID);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", subscription.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", subscription.Parent);
                cmd.Parameters.AddWithValue("@subscriptionId", subscriptionId);
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
        */

        [Route("api/application/{applicationId}/subscription/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSubscription(string applicationId, string subscriptionId)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "DELETE FROM subscription WHERE Id=@subscriptionId AND Parent=@applicationId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subscriptionId", subscriptionId);
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
