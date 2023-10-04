using System;
using System.Data;
using System.Data.SqlClient;

using UserDetails;


namespace DataLayer
{
    /// <summary>
    /// Class for connecting to the SQL database, verifying user details and to store the details in the database.
    /// </summary>
    internal class DataAccess:IDataAccess
    {
        //creating a new sql connection 
        public static SqlConnection connection = new SqlConnection(@"Data Source=192.168.0.30;Initial Catalog=empid255;Persist Security Info=True;Pooling =false;User ID=User5;Password=CDev005#8");

        /// <summary>
        /// specific method for verifying the username in the database.
        /// </summary>
        /// <param name="u_name"></param>
        /// <returns></returns>
        public bool Verify(UserInput userObj)
        {
            
            try
            {
                connection.Open();
                string query = "select count(*) from UDetails where Username=@u_name";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@u_name", userObj.username);
                    int count = (Convert.ToInt32(cmd.ExecuteScalar()));
                   connection.Close();
                    return count > 0;

                }
            }catch(Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close(); 
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
        public bool RegisterUser(UserInput userObj)
        {
            connection.Open();
            string query = "insert into UDetails(Email,Username,Password)values(@email,@username,@password)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Email", userObj.email);
                cmd.Parameters.AddWithValue("@Username", userObj.username);
                cmd.Parameters.AddWithValue("@Password", userObj.password);
                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
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
            connection.Open();
            string query = "select Username,Password from UDetails where Username=@name and Password=@password";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue(@"name", name);
                cmd.Parameters.AddWithValue(@"password", password);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                // Check if any rows were returned (i.e., user exists)
                return dataTable.Rows.Count > 0;
            }
        }

        /// <summary>
        /// Specific method to verify email of an user.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool validEmail(UserInput userObj)
        {
            try
            {
                connection.Open();
                string query = "select email from UDetails where Email=@email";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue(@"email", userObj.email);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    connection.Close();
                    // Check if any rows were returned (i.e., user exists)
                    return dataTable.Rows.Count > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Specific method that helps the user to change or reset their password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        //public bool UpdatePassword(UserInput userObj)
        //{
        //    connection.Open();
        //    DataTable dt = new DataTable();
        //    string query = "update UDetails set Password=@userObj.password where Username=@userObj.username";
        //    using(SqlCommand cmd=new SqlCommand(query, connection))
        //    {
        //        //cmd.Parameters.AddWithValue("@password", password);
        //        //cmd.Parameters.AddWithValue("@username", username);
        //        //int rowsAffect = cmd.ExecuteNonQuery();
        //        //connection.Close();
        //        //return rowsAffect > 0;\
        //        SqlDataReader read = cmd.ExecuteReader();
        //        dt.Load(read);
        //        return dt.Rows.Count > 0;                   

        //    }
        //}
        public bool UpdatePassword(string password, string username)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "UPDATE UDetails SET Password = @password WHERE Username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@username", username);

                        int rowsAffected = (cmd.ExecuteNonQuery());

                        return rowsAffected > 0; // Return true if at least one row was updated
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
