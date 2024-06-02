using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace DemoWebAPP.Model
{
    public class DAL
    {




        public List<Users> GetUsers(IConfiguration configuration)
        {
            List<Users> listUsers = new List<Users>();

            using (MySqlConnection con = new MySqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM user_db.tblusers", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Users users = new Users();
                        users.ID = Convert.ToString(dt.Rows[i]["ID"]);
                        users.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                        users.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                        listUsers.Add(users);

                    }
                }
            }
            return listUsers;

        }

        public int AddUser(Users user, IConfiguration configuration)
        {


            int i = 0;
            using (MySqlConnection con = new MySqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO user_db.tblusers(FirstName,LastName) VALUES('" + user.FirstName + "','" + user.LastName + "')", con);
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();

            }

            return i;
        }


        public Users GetUser(string id, IConfiguration configuration)
        {
            Users user = new Users();

            using (MySqlConnection con = new MySqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM user_db.tblusers WHERE ID ='" + id + "' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {


                    user.ID = Convert.ToString(dt.Rows[0]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);

                }
            }
            return user;



        }


        public int UpdateUser(Users user, IConfiguration configuration)
        {
            int i = 0;
            using (MySqlConnection con = new MySqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE user_db.tblusers SET FirstName ='" + user.FirstName + "' ,LastName='" + user.LastName +"' WHERE ID = '"+user.ID+"'" , con);
                con.Open();
                i = cmd.ExecuteNonQuery(); 
                con.Close();
            } 
            return i;
        }

        public int DeleteUser(string id, IConfiguration configuration)
        {
          
            
            int i = 0;
            using (MySqlConnection con = new MySqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM user_db.tblusers  WHERE ID = '" + id + "'", con);
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }



    }
}
