using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// поле, хранящее проект
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// поле, хранящее список заметок
        /// </summary>
        private List<Note> _noteList;

        /// <summary>
        /// поле, хранящее заголовок категорий
        /// </summary>
        private readonly string _category = "Category: ";

        /// <summary>
        /// поле, хранящее строку "все категории"
        /// </summary>
        private readonly string _allCategories = "All";

        /// <summary>
        /// конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            comboBox.Items.Add(_allCategories);

            var catigories = Enum.GetValues(typeof(NoteCategory));

            foreach (var category in catigories)
            {
                comboBox.Items.Add(category);
            }

            comboBox.SelectedIndex = 0;
            _project = ProjectManager.LoadFromFile(ProjectManager.FileName);
            _project.Notes = _project.SortByEdited(_project.Notes);
            _noteList = _project.Notes;
            ShowInListBox(_noteList);
            int index = _project.IndexOf(_project.CurrentNote, _noteList);
            listBox.SelectedIndex = index;
        }

        /// <summary>
        /// инициализация главной формы
        /// </summary>
        /// <param name="note"></param>
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

        /// <summary>
        /// отображения списка заметок
        /// </summary>
        /// <param name="list"></param>
        private void ShowInListBox(List<Note> list)
        {
            listBox.Items.Clear();

            if(list == null)
            {
                return;
            }

            for(int index = 0; index < list.Count(); index++)
            {
                listBox.Items.Add(list[index].Name);
            }
        }

        /// <summary>
        /// отчистка главной формы
        /// </summary>
        private void ClearMainForm()
        {
            _project.CurrentNote = new Note();
            labelName.Text = "Без названия";
            labelCategory.Text = _category;
            dateTimePickerCreated.Value = DateTime.Now;
            dateTimePickerModified.Value = DateTime.Now;
            textBox.Text = "";
        }

        /// <summary>
        /// проверяет индекс combobox
        /// </summary>
        private void ComboBoxCheckIndex()
        {
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.Text = _allCategories;
            }

            if (comboBox.Text != _allCategories)
            {
                return;
            }
            _noteList = _project.Notes;
            ShowInListBox(_noteList);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new NoteForm(new Note());
            addForm.ShowDialog();
            if(addForm.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            _project.Notes.Add(addForm.Note);
            _project.Notes = _project.SortByEdited(_project.Notes);
            comboBox.Text = _allCategories;
            ComboBoxCheckIndex();
            ClearMainForm();
            Init(_noteList[0]);
            listBox.SelectedIndex = 0;
        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var index  = _project.IndexOf(_noteList[listBox.SelectedIndex], _project.Notes);
            var addForm = new NoteForm(_project.Notes[index]);
            addForm.ShowDialog();
            if(addForm.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            _project.Notes[index] = addForm.Note;
            _project.Notes = _project.SortByEdited(_project.Notes);
            comboBox.Text = _allCategories;
            ComboBoxCheckIndex();
            ClearMainForm();
            index = _project.IndexOf(addForm.Note, _noteList);
            Init(_noteList[0]);
            listBox.SelectedIndex = 0;
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var index = _project.IndexOf(_noteList[listBox.SelectedIndex], _project.Notes);
            _project.Notes.RemoveAt(index);
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            comboBox.Text = "";
            ComboBoxCheckIndex();
            ClearMainForm();
            ShowInListBox(_noteList);
            listBox.SelectedIndex = -1;
        }

        private void SelectInListBox(object sender, EventArgs e)
        {
            var index = listBox.SelectedIndex;
            if(index == -1)
            {
                return;
            }
            Init(_noteList[index]);
        }

        private void SelectedValueInComboBox(object sender, EventArgs e)
        {
            if((comboBox.SelectedItem == null) || (comboBox.SelectedIndex == 0))
            {
                _noteList = _project.Notes;
                ShowInListBox(_noteList);
                return;
            }
            var category = comboBox.SelectedItem.ToString();
            _noteList = _project.SearchByCategory(category, _project).Notes;
            listBox.Items.Clear();
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
            ClearMainForm();
            if(_noteList.Count() == 0)
            {
                return;
            }

            ShowInListBox(_noteList);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBoxCheckIndex();
            ClearMainForm();
        }
    }
}
