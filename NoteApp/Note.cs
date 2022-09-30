using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Note
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public Note(int id, string title, string description, DateTime date, DateTime time)
        {
            ID = id;
            Title = title;
            Description = description;
            Date = date;
            Time = time;
        }
        public static List<Note> notes = new List<Note>();
    }
}
