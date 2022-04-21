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
            //SetUp
            var sourceNote = GetNewNote();
            var expected = "text";

            //Act
            var actual = sourceNote.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void Name_SetCorrectValue()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = sourceNote.Name;

            //Act
            sourceNote.Name = expected;
            var actual = sourceNote.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Name с пустым значением")]
        public void Name_SetEmptyValue()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = "";

            //Act
            sourceNote.Name = "";
            var actual = sourceNote.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Name с длиной значения" +
                            "поля, превышающего 50 символов")]
        public void Name_SetTooLongValue()
        {
            //Act
            var sourceNote = GetNewNote();
            var source = "Слишком длинное название поля," +
                         "превышающее 50 символов и выбрасывающее" +
                         "исключение";

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    sourceNote.Name = source;
                });
        }

        [Test(Description = "Тест геттера NoteCategory")]
        public void NoteCategory_GetCorrectNoteCategory()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = NoteCategory.Home;

            //Act
            var actual = sourceNote.NoteCategory;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера NoteCategory")]
        public void NoteCategory_SetCorrectValue()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = sourceNote.NoteCategory;

            //Act
            sourceNote.NoteCategory = expected;
            var actual = sourceNote.NoteCategory;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера NoteText")]
        public void NoteText_GetCorrectNoteText()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = "info";

            //Act
            var actual = sourceNote.NoteText;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера NoteText")]
        public void NoteText_SetCorrectValue()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = sourceNote.NoteText;

            //Act
            sourceNote.NoteText = expected;
            var actual = sourceNote.NoteText;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера CreateTime")]
        public void CreateTime_GetCorrectCreatedTime()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = new DateTime(2022, 03, 18, 17, 00, 00);

            //Act
            var actual = sourceNote.CreateTime;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера CreateTime")]
        public void CreateTime_SetCorrectCreatedTime()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = sourceNote.CreateTime;

            //Act
            sourceNote.CreateTime = expected;
            var actual = sourceNote.CreateTime;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера LastChange")]
        public void LastChange_GetCorrectChangedTime()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = new DateTime(2022, 03, 18, 17, 05, 00);

            //Act
            var actual = sourceNote.LastChange;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера LastChange")]
        public void LastChange_SetCorrectChangedTime()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = sourceNote.LastChange;

            //Act
            sourceNote.LastChange = expected;
            var actual = sourceNote.LastChange;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест клонирования ICloneable")]
        public void TestClone_ReturnsSameClone()
        {
            //SetUp
            var sourceNote = GetNewNote();
            var expected = (Note)sourceNote.Clone();

            //Assert
            Assert.AreEqual(expected, sourceNote);
        }
    }
}
