using NUnit.Framework;
using NoteApp;

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

        [Test(Description = "Проверка на добавление заметки в коллекцию")]
        public void Project_NotNull()
        {
            _notes.Notes.Add(_note);

            Assert.NotNull(_notes);
        }
    }
}
