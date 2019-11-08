using LifeTheGreenWay.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeTheGreenWay
{
    public class BlogRepository
    {
        private static string connectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<BlogPost> GetPosts()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM entries;";

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                var allPosts = new List<BlogPost>();

                while (reader.Read() == true)
                {
                    var currentPost = new BlogPost();
                    currentPost.ID = reader.GetInt32("ID");
                    currentPost.Title = reader.GetString("Title");
                    currentPost.Date = reader.GetDateTime("Date");
                    currentPost.Content = reader.GetString("content");
                    allPosts.Add(currentPost);
                }

                return allPosts;
            }
        }
    }
}
