using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Note
    {
        private int id;
        private string title;
        private string description;
        private string date;
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public Note(int id, string title, string description, string date)
        {
            ID = id;
            Title = title;
            Description = description;
            Date = date;
        }
        public static List<Note> notes = new List<Note>();
    }
}
