using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Share.Methods
{
    public class Database
    {
        static MySql.Data.MySqlClient.MySqlConnection MySqlConnection;
        static MySql.Data.MySqlClient.MySqlCommand MySqlCommand;
        static string Server = "localhost";
        static string DatabaseName = "share";
        static string Password = "";
        static string User = "root";
        static void StartConnection()
        {
            MySqlConnection = new MySqlConnection("server=" + Server + ";user=" + User + ";password=" + Password + ";database=" + DatabaseName + ";");
        }
        public static string AddUser(Class.User user)
        {
            StartConnection();
            try
            {
                using (MySqlCommand = new MySqlCommand("insert into user (user.ID,user.email,user.name,user.password) values('',@email,@name,@password)", MySqlConnection))
                {
                    MySqlCommand.Parameters.AddWithValue("@email", user.Email.ToLower());
                    MySqlCommand.Parameters.AddWithValue("@name", user.Name);
                    MySqlCommand.Parameters.AddWithValue("@password", user.Password);
                    MySqlConnection.Open();
                    var result = MySqlCommand.ExecuteScalar();
                    if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                    if (result != null)
                    {
                        return "User has been added to database";
                    }
                    else
                    {
                        return "No database result Methods.AddUser()";
                    }
                }
            }
            catch (Exception ex)
            {
                if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                return "Something went wrong in Methods.AddUser()";
            }
        }
        public static Class.User SignInUser(Class.User user)
        {
            StartConnection();
            try
            {
                using (MySqlCommand = new MySqlCommand("select * from user where user.email=@email and user.password=@password", MySqlConnection))
                {
                    MySqlCommand.Parameters.AddWithValue("@email", user.Email.ToLower());
                    MySqlCommand.Parameters.AddWithValue("@password", user.Password);

                    MySqlConnection.Open();
                    MySqlDataReader reader = MySqlCommand.ExecuteReader();
                    Class.User userCredentials = new Class.User();
                    while (reader.Read())
                    {

                        userCredentials.ID = (int)reader["ID"];
                        userCredentials.Name = (string)reader["name"];
                        userCredentials.Email = (string)reader["email"];
                        userCredentials.AlreadyHashedPassword = (string)reader["password"];

                    }
                    if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                    return userCredentials;
                }
            }
            catch (Exception ex)
            {
                if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                return null;
            }
        }
        public static string SendData(Class.File file)
        {
            StartConnection();
            try
            {
                using (MySqlCommand = new MySqlCommand("select user.ID from user where user.email=@email", MySqlConnection))
                {
                    MySqlCommand.Parameters.AddWithValue("@email", file.EmailToUser.ToLower());
                    int SendToID = 0;
                    MySqlConnection.Open();
                    MySqlDataReader reader = MySqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        SendToID = (int)reader["ID"];
                    }
                    if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                    if (SendToID != 0)
                    {
                        using (MySqlCommand = new MySqlCommand("insert into file (ID,data,IsText,datetime) values('',@data,@istext,@datetime)", MySqlConnection))
                        {
                            if (!file.isText)
                            {
                                string fileLocation = UploadFile(file.Data);
                                MySqlCommand.Parameters.AddWithValue("@data", fileLocation ?? throw new Exception("Couldn't save file to server"));
                                MySqlCommand.Parameters.AddWithValue("@istext", file.isText);
                                MySqlCommand.Parameters.AddWithValue("@datetime", file.Datetime);
                            }
                            else
                            {
                                MySqlCommand.Parameters.AddWithValue("@data", file.Data);
                                MySqlCommand.Parameters.AddWithValue("@istext", file.isText);
                                MySqlCommand.Parameters.AddWithValue("@datetime", file.Datetime);
                            }
                            MySqlConnection.Open();
                            MySqlCommand.ExecuteScalar();
                            long FileID = MySqlCommand.LastInsertedId;
                            if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                            if (FileID != 0)
                            {
                                using (MySqlCommand = new MySqlCommand("insert into file_user (fileid,userid,sendtoid) values(@fileid,@userid,@sendtoid)", MySqlConnection))
                                {
                                    MySqlCommand.Parameters.AddWithValue("@fileid", FileID);
                                    MySqlCommand.Parameters.AddWithValue("@userid", file.FromUser.ID);
                                    MySqlCommand.Parameters.AddWithValue("@sendtoid", file.EmailToUser);
                                    MySqlConnection.Open();
                                    MySqlCommand.ExecuteScalar();
                                    if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                                    return "Send succesfully";
                                }
                            }
                            else
                            {
                                throw new Exception("File isn't saved");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("No user found with the specified e-mailadress");
                    }
                }
            }
            catch (Exception ex)
            {
                if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                return "Something went wrong: " + ex.Message;
            }
        }
        /// <summary>
        /// Saves a file to server and returns the filelocation
        /// </summary>
        /// <param name="CurrentFileLocation"></param>
        /// <returns></returns>
        public static string UploadFile(string CurrentFileLocation)
        {
            return null;
        }
        public static List<Class.File> GetFiles(Class.User LoggedInUser)
        {
            StartConnection();
            try
            {
                if (LoggedInUser != null)
                {
                    using (MySqlCommand = new MySqlCommand("select file_user.FileID, file_user.SendToID, file.Data, file.isText, file.DateTime, user.ID, user.Email, user.Name from file_user join file on file.ID=file_user.FileID join user on user.ID=file_user.UserID where file_user.SendToID=@sendTo", MySqlConnection))
                    {
                        MySqlCommand.Parameters.AddWithValue("@sendTo", LoggedInUser.Email);
                        MySqlConnection.Open();
                        List<Class.File> Files = new List<Class.File>();
                        MySqlDataReader reader = MySqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Class.File file = new Class.File();
                            file.ID = (int)reader["fileid"];
                            file.EmailToUser = (string)reader["sendtoid"];
                            file.Data = (string)reader["data"];
                            file.isText = (bool)reader["IsText"];
                            file.Datetime = (DateTime)reader["datetime"];
                            file.FromUser = new Class.User()
                            {
                                Email = (string)reader["email"],
                                ID = (int)reader["ID"],
                                Name = (string)reader["name"]
                            };
                            Files.Add(file);
                        }
                        if (MySqlConnection.State != System.Data.ConnectionState.Closed) { MySqlConnection.Close(); }
                        return Files;
                    }
                }
                else
                {
                    throw new Exception("You need to be logged in to perform this action!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
