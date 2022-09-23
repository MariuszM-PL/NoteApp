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
            string date = DateTime.Now.ToString();
            DatabaseSQL.InsertDataDB(title, note, date);

            tbTitle.Clear();
            txtNote.Clear();
            lblDateValue.Text = "";

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
                    lblDateValue.Text = note.Date;
                }
            }
        }
    }
}