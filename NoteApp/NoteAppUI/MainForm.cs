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
            _project = ProjectManager.LoadFromFile(ProjectManager.FileName);
            _realProject = _project;
            ShowInListBox(_realProject);
            comboBox.Text = "All";
        }

        void ClearMainForm()
        {
            labelName.Text = "Без названия";
            labelCategory.Text = _category;
            dateTimePickerCreated.Value = DateTime.Now;
            dateTimePickerModified.Value = DateTime.Now;
            comboBox.Text = "All";
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
            ClearMainForm();
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
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            comboBox.Text = "All";
            ComboBoxTextChanged();
            listBox.SelectedIndex = _realProject.Notes.Count() - 1;
        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Warning", "Select note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            comboBox.Text = "All";
            ComboBoxTextChanged();
            Init(_realProject.Notes[index]);
            listBox.SelectedIndex = -1;
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Warning", "Select note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var index = _project.IndexOf(_realProject.Notes[listBox.SelectedIndex], _project.Notes);
            _project.Notes.RemoveAt(index);
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            comboBox.Text = "";
            ComboBoxTextChanged();
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
        }
    }
}
