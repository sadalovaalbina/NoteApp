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
    }
}
