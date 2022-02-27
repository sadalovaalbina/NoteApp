using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проекта
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Свойство, хранящее список заметок
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();

        public Note CurrentNote { get; set; }

        /// <summary>
        /// Возвращает отсортированный в порядке убывания
        /// даты изменения заметки список
        /// </summary>
        /// <param name="notSortedList"></param>
        /// <returns></returns>
        public List<Note> SortByEdited(List<Note> notSortedList)
        {
            var sortedNotes = notSortedList.OrderByDescending(item => item.LastChange).ToList();
            return sortedNotes;
        }

        /// <summary>
        /// Возвращается отсортированный в порядке убывания
        /// даты изменения заметки список определенной категории
        /// </summary>
        /// <param name="notSortedList"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Note> SortByEditedAndCategory(List<Note> notSortedList, NoteCategory category)
        {
            var sortedNotesCategory = notSortedList.Where(item => item.NoteCategory == category).ToList();
            var sortedNotes = sortedNotesCategory.OrderByDescending(item => item.LastChange).ToList();
            return sortedNotes;
        }

        public Project SearchByCategory(string category, Project project)
        {
            if(category == "")
            {
                return project;
            }

            var newProject = new Project();

            if(project == null)
            {
                return newProject;
            }

            for(int index = 0; index < project.Notes.Count(); index++)
            {
                if(project.Notes[index].NoteCategory.ToString() == category)
                {
                    newProject.Notes.Add(project.Notes[index]);
                }
            }
            return newProject;
        }

        public int IndexOf(Note note, List<Note> list)
        {
            for(int index = 0; index < list.Count; index++)
            {
                if(note.Equals(list[index]))
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
