namespace NoteApp
{
    public partial class Form1 : Form
    {
        private int id;
        private string title;
        ListBox listElements;
        public Form1()
        {
            InitializeComponent();
            DatabaseSQL.CreateDB();
            DatabaseSQL.GetDataDB();
            listElements = listNotes;
            DatabaseSQL.DisplayList(listElements);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string note = txtNote.Text;
            string date = dateTimePick.Value.ToString();
            //string date = DateTime.Now.ToString();
            DatabaseSQL.InsertDataDB(title, note, date);

            tbTitle.Clear();
            txtNote.Clear();

            //lblDateValue.Text = "";

            DatabaseSQL.GetDataDB();
            DatabaseSQL.DisplayList(listElements);
        }

        private void listNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

            string s = listNotes.SelectedItem.ToString();
            string[] subs = s.Split('.');
            foreach(var sub in subs)
            {
                if(Int32.TryParse(sub, out int number))
                {
                    id = number;
                }
                else
                {
                    title = sub;
                }
            }
            foreach (var note in Note.notes)
            {
                if(note.ID == id && note.Title == title)
                {
                    tbTitle.Text = note.Title;
                    txtNote.Text = note.Description;
                    dateTimePick.Value = DateTime.Parse(note.Date);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idNote = 0;
            if(listNotes.SelectedItem != null)
            {
                string? selectedNote = listNotes.SelectedItem.ToString();
                string[] idNotes = selectedNote.Split(".");
                foreach(string id in idNotes)
                {
                    if(Int32.TryParse(id, out idNote))
                    {
                        break;
                    }
                }

                DatabaseSQL.DeleteDataDB(idNote);
                DatabaseSQL.GetDataDB();
                DatabaseSQL.DisplayList(listElements);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.ForeColor = Color.Black;
            btnAdd.BackColor = Color.FromArgb(253, 227, 102);
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.ForeColor = Color.FromArgb(253, 227, 102);
            btnAdd.BackColor = Color.Black;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.ForeColor = Color.FromArgb(253, 227, 102);
            btnDelete.BackColor = Color.Black;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.ForeColor = Color.Black;
            btnDelete.BackColor = Color.FromArgb(253, 227, 102);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.FromArgb(253, 227, 102);
            btnExit.BackColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.Black;
            btnExit.BackColor = Color.FromArgb(253, 227, 102);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }
    }
}