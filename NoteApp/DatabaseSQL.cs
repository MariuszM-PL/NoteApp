using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Collections;

namespace NoteApp
{
    public class DatabaseSQL
    {
        private static string? srvAddress;
        private static string? username;
        private static string? password;
        private static string? connectionString;
        private static SqlConnection? newConnection;

        /// <summary>
        /// MS SQL settings for connection from database.txt file
        /// </summary>
        public static void SettingsDB()
        {
            List<string> settings = new List<string>();
            string path = @$"{Application.StartupPath}\database.txt";
            var lines = File.ReadLines(path);
            foreach(var line in lines)
            {
                settings.Add(line);
            }
            srvAddress = settings[0];
            username = settings[1];
            password = settings[2];
            connectionString = @$"Data Source={srvAddress};User Id={username};Password={password};Initial Catalog=NoteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            newConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Function for open and close connect to MS SQL database
        /// </summary>
        public static void CreateConnectDB()
        {
            if(newConnection != null)
            {
                try
                {
                    newConnection.Open();
                }
                catch (Exception e)
                {
                    newConnection.Close();
                    MessageBox.Show(e.ToString());
                }
            }            
        }

        public static void CreateDB()
        {
            CreateConnectDB();
            string query = @"CREATE TABLE Notes (
                id int identity(1,1) NOT NULL PRIMARY KEY,
                title VARCHAR(255) NOT NULL,
                note VARCHAR(255),
                date VARCHAR(255),
                time VARCHAR(255)
            )";
            try
            {
                SqlCommand cmd = new SqlCommand(query, newConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New database created...");
            }
            catch (SqlException e)
            {
                if(e.Message.ToLower().Contains("already exists"))
                {
                    MessageBox.Show("Database was created early...");
                }
            }
            if(newConnection != null)
               newConnection.Close();
        }

        public static void InsertDataDB(string title, string note, string date, string time)
        {
            CreateConnectDB();
            string query = "INSERT INTO Notes(title, note, date, time) VALUES(@title, @note, @date, @time)";
            SqlCommand cmd = new SqlCommand(query, newConnection);

            cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 255)).Value = title;
            cmd.Parameters.Add("@note", SqlDbType.VarChar, 255).Value = note;
            cmd.Parameters.Add("@date", SqlDbType.VarChar, 255).Value = date;
            cmd.Parameters.Add("@time", SqlDbType.VarChar, 255).Value = time;
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            MessageBox.Show("New note saved in database");
            if (newConnection != null)
                newConnection.Close();
        }

        public static void DeleteDataDB(int id)
        {
            CreateConnectDB();
            string query = "DELETE FROM Notes WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query, newConnection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Note was deleted from database");
            if (newConnection != null)
                newConnection.Close();
        }
        public static void GetDataDB()
        {
            CreateConnectDB();
            string query = "SELECT * FROM Notes";
            SqlCommand cmd = new SqlCommand(query, newConnection);

            using SqlDataReader rdr = cmd.ExecuteReader();
            Note.notes.Clear();
            while (rdr.Read())
            {
                Note note = new Note(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), DateTime.Parse(rdr.GetString(3)), DateTime.Parse(rdr.GetString(4)));
                Note.notes.Add(note);
            }
            MessageBox.Show("Notes from database are restored...");
            if (newConnection != null)
                newConnection.Close();

        }

        public static void DisplayList(ListBox listElements)
        {
            listElements.Items.Clear();
            Note.notes = Note.notes.OrderBy(x => x.Date).ToList();
            foreach (var note in Note.notes)
            {
                listElements.Items.Add($"{note.ID}.{note.Title}");
                if(Convert.ToInt32(note.Date.Day) < 10)
                {
                    listElements.Items.Add($"(0{note.Date.Day}-{note.Date.Month}-{note.Date.Year})");
                    //listElements.Items.Add($"{note.Time}");
                }
                else 
                {
                    listElements.Items.Add($"({note.Date.Day}-{note.Date.Month}-{note.Date.Year})");
                    //listElements.Items.Add($"{note.Time}");
                }
                
            }
        }  
    }
}
