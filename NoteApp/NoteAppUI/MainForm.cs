using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //Init(_project.Notes[0]);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _realProject.Notes.Add(new Note());
            _realProject.Notes[0].Name = "note";
            _realProject.Notes[0].NoteCategory = NoteCategory.Docs;
            _realProject.Notes[0].NoteText = "notenotenotenotenotenotenonteoonotenotenoetnoet";
            ProjectManager.SaveToFile(_realProject, ProjectManager.FileName);
        }

        private void SelectInListBox(object sender, EventArgs e)
        {
            var index = listBox.SelectedIndex;
            Init(_realProject.Notes[index]);
        }

        private void SelectedValueInComboBox(object sender, EventArgs e)
        {
            _realProject = _project.SearchByCategory(comboBox.SelectedItem.ToString(), _project);
            listBox.Items.Clear();
            if(_realProject.Notes.Count() == 0)
            {
                return;
            }

            ShowInListBox(_realProject);
            listBox.SelectedIndex = 0;
            //todo: Добавить отчистку полей на главной форме
        }
    }
}
