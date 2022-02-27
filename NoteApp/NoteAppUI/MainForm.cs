using System;
using System.Linq;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        private Project _project = new Project();

        private Project _realProject = new Project();

        private readonly string _category = "Category: ";

        private void Init(Note note)
        {
            if (note.NoteText == null)
            {
                return;
            }
            _project.CurrentNote = note;
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            labelName.Text = note.Name;
            labelCategory.Text = _category + note.NoteCategory.ToString();
            textBox.Text = note.NoteText;
            dateTimePickerCreated.Value = note.CreateTime;
            dateTimePickerModified.Value = note.LastChange;
        }

        private void ShowInListBox(Project project)
        {
            listBox.Items.Clear();

            if(project == null)
            {
                return;
            }

            for(int index = 0; index < project.Notes.Count(); index++)
            {
                listBox.Items.Add(project.Notes[index].Name);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 7;
            _project = ProjectManager.LoadFromFile(ProjectManager.FileName);
            _project.Notes = _project.SortByEdited(_project.Notes);
            _realProject = _project;
            ShowInListBox(_realProject);
            int index = _realProject.IndexOf(_project.CurrentNote, _project.Notes);
            listBox.SelectedIndex = index;
        }

        void ClearMainForm()
        {
            _project.CurrentNote = new Note();
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            labelName.Text = "Без названия";
            labelCategory.Text = _category;
            dateTimePickerCreated.Value = DateTime.Now;
            dateTimePickerModified.Value = DateTime.Now;
            textBox.Text = "";
        }

        public void ComboBoxTextChanged()
        {
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.Text = "All";
            }

            if (comboBox.Text != "All")
            {
                return;
            }
            _realProject = _project;
            ShowInListBox(_realProject);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new EditForm(new Note());
            addForm.ShowDialog();
            if(addForm.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            _project.Notes.Add(addForm.Note);
            _project.Notes = _project.SortByEdited(_project.Notes);
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            _realProject = _project;
            comboBox.Text = "All";
            ComboBoxTextChanged();
            ClearMainForm();
            Init(_realProject.Notes[0]);
            listBox.SelectedIndex = 0;
        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var index  = _project.IndexOf(_realProject.Notes[listBox.SelectedIndex], _project.Notes);
            var addForm = new EditForm(_project.Notes[index]);
            addForm.ShowDialog();
            if(addForm.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            _project.Notes[index] = addForm.Note;
            _project.Notes = _project.SortByEdited(_project.Notes);
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            _realProject = _project;
            comboBox.Text = "All";
            ComboBoxTextChanged();
            ClearMainForm();
            index = _realProject.IndexOf(addForm.Note, _realProject.Notes);
            Init(_realProject.Notes[0]);
            listBox.SelectedIndex = 0;
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var index = _project.IndexOf(_realProject.Notes[listBox.SelectedIndex], _project.Notes);
            _project.Notes.RemoveAt(index);
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            _realProject = _project;
            comboBox.Text = "";
            ComboBoxTextChanged();
            ClearMainForm();
            ShowInListBox(_realProject);
            listBox.SelectedIndex = -1;
        }

        private void SelectInListBox(object sender, EventArgs e)
        {
            var index = listBox.SelectedIndex;
            if(index == -1)
            {
                return;
            }
            Init(_realProject.Notes[index]);
        }

        private void SelectedValueInComboBox(object sender, EventArgs e)
        {
            if((comboBox.SelectedItem == null) || (comboBox.SelectedIndex == 7))
            {
                _realProject = _project;
                ShowInListBox(_realProject);
                return;
            }
            var category = comboBox.SelectedItem.ToString();
            _realProject = _project.SearchByCategory(category, _project);
            listBox.Items.Clear();
            ClearMainForm();
            if(_realProject.Notes.Count() == 0)
            {
                return;
            }

            ShowInListBox(_realProject);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBoxTextChanged();
            ClearMainForm();
        }
    }
}
