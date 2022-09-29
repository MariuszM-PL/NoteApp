using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace NoteApp
{
    public class DatabaseSQL
    {
        private static string connectionString = @"Data Source=DESKTOP-T5KFV74\SQLEXPRESS;Initial Catalog=NoteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlConnection newConnection = new SqlConnection(connectionString);

        public static void CreateConnectDB()
        {
            try
            {
                newConnection.Open();
            }
            catch (Exception e)
            {
                newConnection.Close();
                //newConnection.Open();
            }
            
        }

        public static void CreateDB()
        {
            string query = @"CREATE TABLE Notes (
                id int identity(1,1) NOT NULL PRIMARY KEY,
                title VARCHAR(255) NOT NULL,
                note VARCHAR(255),
                date VARCHAR(255)
            )";
            try
            {
                SqlCommand cmd = new SqlCommand(query, newConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New database created...");
            }
            catch (Exception e)
            {
                MessageBox.Show("Database was created early...");
            }

            newConnection.Close();
        }
        public static void InsertDataDB(string title, string note, string date)
        {
            CreateConnectDB();
            string query = "INSERT INTO Notes(title, note, date) VALUES(@title, @note, @date)";
            SqlCommand cmd = new SqlCommand(query, newConnection);

            cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 255)).Value = title;
            cmd.Parameters.Add("@note", SqlDbType.VarChar, 255).Value = note;
            cmd.Parameters.Add("@date", SqlDbType.VarChar, 255).Value = date;
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            MessageBox.Show("New data sended to database");
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
                Note note = new Note(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                Note.notes.Add(note);
            }
            MessageBox.Show("Values from database are restored...");
            newConnection.Close();

        }

        public static void DisplayList(ListBox listElements)
        {
            listElements.Items.Clear();
            foreach(var note in Note.notes)
            {
                listElements.Items.Add($"{note.ID}.{note.Title}");
            }
        }

        
    }
}
