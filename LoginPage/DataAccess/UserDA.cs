using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    /// <summary>
    /// Class for connecting to the SQL database, verifying user details and to store the details in the database.
    /// </summary>
    public class UserDA
    {
        //creating a new sql connection 
        public static SqlConnection con = new SqlConnection(@"Data Source=192.168.0.30;Initial Catalog=empid255;Persist Security Info=True;User ID=User5;Password=CDev005#8");

        /// <summary>
        /// specific method for verifying the username in the database.
        /// </summary>
        /// <param name="u_name"></param>
        /// <returns></returns>
        public bool Verify(string u_name)
        {
            con.Open();
            string query = "select count(*) from UDetails where Username=@u_name";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@u_name", u_name);
                int count = (Convert.ToInt32(cmd.ExecuteScalar()));
                con.Close();
                return count > 0;
            }
        }
        
        /// <summary>
        /// specific method for storing the details of the user into the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public bool RegisterUser(string email,string username,string password,string gender)
        {
            con.Open();
            string query = "insert into UDetails(Email,Username,Password,gender)values(@email,@username,@password,@gender)";
            using (SqlCommand cmd = new SqlCommand(query, con)) {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@gender", gender);
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected > 0;
            }

        }
        
        /// <summary>
        /// specific method to check if the user details are present in the database.
        /// If details are found the method returns true and login is successful.
        /// else if login isn't successful.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginUser(string name, string password)
        {
            con.Open();
            String query = "select Username,Password from UDetails where Username=@name and Password=@password";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue(@"name", name);
                cmd.Parameters.AddWithValue(@"password", password);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                // Check if any rows were returned (i.e., user exists)
                return dataTable.Rows.Count > 0;

            }
        }
        
        /// <summary>
        /// Specific method to verify email of an user.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool validEmail(string email)
        {
            con.Open();
            string query = "select email from UDetails where Email=@email";
            using(SqlCommand cmd=new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue(@"email", email);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                // Check if any rows were returned (i.e., user exists)
                return dataTable.Rows.Count > 0;
            }
        }

        /// <summary>
        /// Specific method that helps the user to change or reset their password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool UpdatePassword(string password,string email)
        {
            con.Open();
            string query = "update UDetails set Password=@password where Email=@email";
            using(SqlCommand cmd=new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password",password);
                int rowsAffect = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffect > 0;
            }
        }

    }
}