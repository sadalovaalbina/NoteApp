using NUnit.Framework;
using System;
using NoteApp;

namespace NoteAppUnitTests
{
    /// <summary>
    /// Определение классов юнит-тестирования
    /// </summary>
    [TestFixture]
    public class NoteTest
    {
        /// <summary>
        /// Метод, выполняющийся каждый раз перед запуском теста
        /// Создает экземпляр заметки
        /// </summary>
        public Note GetNewNote()
        {
            var sourceNote = new Note
            {
                Name = "text",
                NoteCategory = NoteCategory.Home,
                NoteText = "info",
                CreateTime = new DateTime(2022, 03, 18, 17, 00, 00),
                LastChange = new DateTime(2022, 03, 18, 17, 05, 00)
            };

            return sourceNote;
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void Name_GetCorrectValue()
        {
            var sourceNote = GetNewNote();
            var expected = "text";

            var actual = sourceNote.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void Name_SetCorrectValue()
        {
            var sourceNote = GetNewNote();
            var expected = sourceNote.Name;

            sourceNote.Name = expected;
            var actual = sourceNote.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Name с пустым значением")]
        public void Name_SetEmptyValue()
        {
            var sourceNote = GetNewNote();
            var expected = "";

            sourceNote.Name = "";
            var actual = sourceNote.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Name с длиной значения" +
                            "поля, превышающего 50 символов")]
        public void Name_SetTooLongValue()
        {
            var sourceNote = GetNewNote();
            var source = "Слишком длинное название поля," +
                         "превышающее 50 символов и выбрасывающее" +
                         "исключение";

            Assert.Throws<ArgumentException>(
                () =>
                {
                    sourceNote.Name = source;
                });
        }

        [Test(Description = "Тест геттера NoteCategory")]
        public void NoteCategory_GetCorrectNoteCategory()
        {
            var sourceNote = GetNewNote();
            var expected = NoteCategory.Home;

            var actual = sourceNote.NoteCategory;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера NoteCategory")]
        public void NoteCategory_SetCorrectValue()
        {
            var sourceNote = GetNewNote();
            var expected = sourceNote.NoteCategory;

            sourceNote.NoteCategory = expected;
            var actual = sourceNote.NoteCategory;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера NoteText")]
        public void NoteText_GetCorrectNoteText()
        {
            var sourceNote = GetNewNote();
            var expected = "info";

            var actual = sourceNote.NoteText;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера NoteText")]
        public void NoteText_SetCorrectValue()
        {
            var sourceNote = GetNewNote();
            var expected = sourceNote.NoteText;

            sourceNote.NoteText = expected;
            var actual = sourceNote.NoteText;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера CreateTime")]
        public void CreateTime_GetCorrectCreatedTime()
        {
            var sourceNote = GetNewNote();
            var expected = new DateTime(2022, 03, 18, 17, 00, 00);

            var actual = sourceNote.CreateTime;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера CreateTime")]
        public void CreateTime_SetCorrectCreatedTime()
        {
            var sourceNote = GetNewNote();
            var expected = sourceNote.CreateTime;

            sourceNote.CreateTime = expected;
            var actual = sourceNote.CreateTime;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера LastChange")]
        public void LastChange_GetCorrectChangedTime()
        {
            var sourceNote = GetNewNote();
            var expected = new DateTime(2022, 03, 18, 17, 05, 00);

            var actual = sourceNote.LastChange;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера LastChange")]
        public void LastChange_SetCorrectChangedTime()
        {
            var sourceNote = GetNewNote();
            var expected = sourceNote.LastChange;

            sourceNote.LastChange = expected;
            var actual = sourceNote.LastChange;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест клонирования ICloneable")]
        public void TestClone_ReturnsSameClone()
        {
            var sourceNote = GetNewNote();
            var expected = (Note)sourceNote.Clone();

            Assert.AreEqual(expected, sourceNote);
        }
    }
}
