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
