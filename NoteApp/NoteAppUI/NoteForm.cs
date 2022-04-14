using System;
using System.Drawing;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class NoteForm : Form
    {
        private readonly Color errorColor = Color.Crimson;

        private readonly Color whiteColor = Color.White;

        public Note Note { get; set; }

        public NoteForm(Note note)
        {
            Note = note;
            InitializeComponent();

            comboBox.Items.Add("All");

            var categories = Enum.GetValues(typeof(NoteCategory));
            
            foreach(var category in categories)
            {
                comboBox.Items.Add(category);
            }

            if(Note == null)
            {
                return;
            }
            textBoxTitle.Text = Note.Name;
            comboBox.Text = Note.NoteCategory.ToString();
            dateTimePickerCreated.Value = Note.CreateTime;
            dateTimePickerModified.Value = Note.LastChange;
            textBoxText.Text = Note.NoteText;
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            if(textBoxTitle.Text == "")
            {
                textBoxText.BackColor = whiteColor;
                return;
            }

            try
            {
                Note.Name = textBoxTitle.Text;
                textBoxTitle.BackColor = whiteColor;
            }
            catch(ArgumentException)
            {
                textBoxTitle.BackColor = errorColor;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Note.NoteCategory = (NoteCategory)comboBox.SelectedIndex;
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            Note.NoteText = textBoxText.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string error = "";
            if((Note.Name == "")||(textBoxTitle.BackColor == errorColor))
            {
                error += "Wrong title\n";
            }
            if((comboBox.SelectedIndex < 0) || (comboBox.SelectedIndex > 6))
            {
                error += "Wrong category\n";
            }
            if(textBoxText.Text == "")
            {
                error += "Wrong text";
            }

            if(error != "")
            {
                MessageBox.Show(error, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
