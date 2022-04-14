using NUnit.Framework;
using NoteApp;
using System;
using System.Collections.Generic;

namespace NoteAppUnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        /// <summary>
        /// Экземпляр проекта
        /// </summary>
        private readonly Project _notes = new Project();

        /// <summary>
        /// Экземпляр заметки
        /// </summary>
        private readonly Note _note = new Note();

        /// <summary>
        /// Метод возвращает экземпляр проекта 
        /// </summary>
        /// <returns></returns>
        private Project GetProject()
        {
            var list = new List<Note>
            {
                new Note
                    {
                        Name = "text",
                        NoteCategory = NoteCategory.Home,
                        NoteText = "info",
                        CreateTime = new DateTime(2022, 03, 17, 17, 00, 00),
                        LastChange = new DateTime(2022, 03, 17, 17, 05, 00)
                    },
                new Note
                    {
                        Name = "text2",
                        NoteCategory = NoteCategory.Docs,
                        NoteText = "info2",
                        CreateTime = new DateTime(2022, 03, 18, 17, 00, 00),
                        LastChange = new DateTime(2022, 03, 18, 17, 05, 00)
                    }
            };

            var project = new Project();
            project.Notes = list;

            return project;
        }

        [Test(Description = "Проверка на добавление заметки в коллекцию")]
        public void Project_NotNull()
        {
            _notes.Notes.Add(_note);

            Assert.NotNull(_notes);
        }

        [Test(Description = "Проверка сортировки")]
        public void Project_SortedByEdited()
        {
            var project = GetProject();
            var expected = project.Notes[0];
            var list = project.SortByEdited(project.Notes);

            var actual = list[1];

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Проверка возврата индекса")]
        public void Project_IndexOf()
        {
            var project = GetProject();
            var note = project.Notes[1];
            var expected = 1;

            var actual = project.IndexOf(note, project.Notes);

            Assert.AreEqual(expected, actual);
        }
    }
}
