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

        [Route("api/subscription")]
        public IEnumerable<Subscription> GetAllSubscriptions()
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM subscription";
                SqlCommand cmd = new SqlCommand(sql, conn);

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

        [Route("api/subscription/{id}")]
        public IHttpActionResult GetSubscriptionById(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "SELECT * FROM subscription WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

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
        }

        [Route("api/modules")]
        [HttpPost]
        public IHttpActionResult StoreSubscription(Subscription subscription)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "INSERT INTO subscription (Name, Creation_dt, Parent, Event, Endpoint) VALUES (@name, @creation_dt, @parent, @event, @endpoint)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", subscription.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", subscription.Parent);
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

        [Route("api/subscription/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateSubscription(Subscription subscription)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "UPDATE subscription SET Name=@name, Creation_dt=@creation_dt, Parent=@parent, Event = @event, EndPoint = @endpoint WHERE Id=@id";
                
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", subscription.Name);
                cmd.Parameters.AddWithValue("@creation_dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@parent", subscription.Parent);
                cmd.Parameters.AddWithValue("@id", subscription.Id);

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

        [Route("api/subscription/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSubscription(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection_string);
                conn.Open();
                string sql = "DELETE FROM subscription WHERE Id=@id";
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
}